using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QLBH.Models;
using QLBH.Commons;
using QLBH.Business;
using QLBH.Repository;
using QLBH.Models.Entities;
using System.Security.Claims;
using QLBH.Commons.Responces;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using static QLBH.Commons.Enums;
using static QLBH.Commons.HepperStr;
using static QLBH.Commons.Common_Constants;
using static QLBH.Commons.MailHepper;
using static QLBH.Commons.Common_Constants.Clames;
using ErrorLogin = QLBH.Commons.Common_Constants.Login;
using BCryptNet = BCrypt.Net.BCrypt;
using ErrorRegister = QLBH.Commons.Common_Constants.Register_Create;

namespace QLBH.Business
{
    public class AuthServices : IAuthServices
    {
        private readonly EmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;
        private readonly IBaseRepository<Account> _baseRepositoryAccount;
        private readonly IBaseRepository<RefeshToken> _baseRepositoryRefesh;
        private readonly IBaseRepository<Decentralization> _baseDeRepositoryDece;
        private readonly IBaseRepository<MailSetting> _baseRepositoryMailsetting;
        private readonly IBaseRepository<ConfirmEmail> _baseRepositoryConfirm;
        private readonly ResponcesObject<DataResponseToken> _responObject;

        public AuthServices(EmailSender emailSender
            , AppDbContext appDbContext, IConfiguration configuration
            , ResponcesObject<DataResponseToken> responObject
            , IBaseRepository<Account> baseRepositoryAccount
            , IBaseRepository<MailSetting> baseRepositoryMailsetting
            , IBaseRepository<Decentralization> baseRepositoryDece
            , IBaseRepository<ConfirmEmail> baseRepositoryConfirm)
        {
            _emailSender = emailSender;
            _responObject = responObject;
            _appDbContext = appDbContext;
            _configuration = configuration;

            _baseRepositoryConfirm = baseRepositoryConfirm;
            _baseDeRepositoryDece = baseRepositoryDece;
            _baseRepositoryAccount = baseRepositoryAccount;
            _baseRepositoryMailsetting = baseRepositoryMailsetting;
        }

        public async Task<DataResponseToken> GenenrateRquestToken(Account Account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection(AppSettingKeys.AUTH_SECRET).Value);
            var RoleID = (await _baseDeRepositoryDece.GetAllAsync(record => record.AccountID == Account.ID && record.Deleted == false))
                .Select(x => (long)x.role);

            var roleName = string.Join(";", _appDbContext.Role.Where(record => RoleID.Contains(record.Role_ID)).Select(x => x.Role_Name));

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ID, Account.ID.ToString()),
                    new Claim(ClaimTypes.Email, Account.Email),
                    new Claim(USER, Account.User_Name),
                    new Claim(ROLES, roleName)
                }),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDes);
            var accesstoken = jwtTokenHandler.WriteToken(token);
            //generate Refesh Token
            var refreshToken = GenerateRefreshToken();
            //Add refesh Token
            await AddRefeshToken(Account, refreshToken);
            return new DataResponseToken
            {
                AccessToken = accesstoken,
                RefreshToken = refreshToken
            };
        }
        public async Task Validate(string User, string Email)
        {
            var account = await _baseRepositoryAccount.GetAllAsync(record => record.User_Name.ToLower() == User.ToLower() || record.Email.ToLower() == Email.ToLower() && record.Deleted == false);
            if (account.Count() > 0)
            {
                throw new Exception();
            }
        }
        public async Task AddRefeshToken(Account account, string refeshToken)
        {
            var refeshTokens = new List<RefeshToken>
            {
                new RefeshToken
                {
                    Token = refeshToken,
                    Date_Expired = DateTime.Now.AddDays(1),
                    AccountID = account.ID,
                    Deleted = false,
                    Account = account
                }
            };
            account.RefeshToken = refeshTokens;
            await _baseRepositoryAccount.UpdateAsync(account);
        }
        public string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var item = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _appDbContext.Account.AsQueryable();
        }

        public async Task<ResponcesObject<DataResponseToken>> Login(Request_Login request_Login)
        {
            if (request_Login.UserName.IsNullOrEmpty() || request_Login.Password.IsNullOrEmpty())
                return _responObject.ResponcesError(StatusCodes.Status400BadRequest, ErrorLogin.Request_NULL, null);

            if (_appDbContext.Account.Any(x => x.User_Name == request_Login.UserName || x.Email == request_Login.UserName && x.Deleted == false))
            {
                var account = await _baseRepositoryAccount.GetAsync(x => x.User_Name == request_Login.UserName || x.Email == request_Login.UserName && x.Deleted == false);
                bool CheckPass = BCryptNet.Verify(request_Login.Password, account.PassWord);
                if (!CheckPass)
                    return _responObject.ResponcesError(StatusCodes.Status400BadRequest, ErrorLogin.Error_Pass, null);
                var acc = await GenenrateRquestToken(account);
                return _responObject.ResponcesSuccess(SUCCESS, acc);
            }
            return _responObject.ResponcesError(StatusCodes.Status400BadRequest, ErrorLogin.Error_USER_NAME, null);
        }
        public List<Cart> GenerateCart()
        {
            return new List<Cart>
            {
                new Cart {}
            };
        }
        public async Task<Tuple<int, string>> Register(Request_Register request_Register)
        {
            var accounts = await _baseRepositoryAccount.GetAllAsync(record => record.IsConfirm < DateTime.Now && record.Deleted == false && record.Work == false);

            if (accounts.Count() != 0)
            {
                foreach (var item in accounts)
                {
                    item.Deleted = true;
                }
                await _baseRepositoryAccount.UpdateAsync(accounts);
            }
            await Validate(request_Register.User_Name, request_Register.Email);

            if (request_Register.PassWord != request_Register.NewPassword)
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.PASSWORD_ERROR);
            //check Password
            var checkpass = HepperStr.CheckPass(request_Register.NewPassword);
            if (checkpass != Enums.Hepper.Success)
                return Tuple.Create(StatusCodes.Status402PaymentRequired, Handle.ConLog(checkpass));
            //check phone_number
            if (!Number(request_Register.Phone_Number) || request_Register.Phone_Number.Length != 10)
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Phone_ERROR_TYPE);
            //check is validate Email
            if (!IsValidateEmail(request_Register.Email))
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Error_Email_TYPE);
            //Phone account Checked
            if (_appDbContext.Account.Any(x => x.Phone_Number == request_Register.Phone_Number && x.Deleted == false))
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Phone_ERROR);
            else
            {
                var account = await GenerateAccount(request_Register);
                await _baseRepositoryAccount.CreateAsync(account);

                await SenderEmail(account);

                return Tuple.Create(StatusCodes.Status200OK, SUCCESS);
            }
        }
        public async Task SenderEmail(Account account)
        {
            var confirm = await _baseRepositoryConfirm.GetAsync(record => record.Account.ID == account.ID && record.IsConfirmed == false);
            var mailsetting = await _baseRepositoryMailsetting.GetAsync(record => record.ID == confirm.MailSetting.ID);

            await _emailSender.SendEmailAsync(account.Email, mailsetting.TieuDe + "(" + mailsetting.Title + ")", string.Format(mailsetting.NoiDung, confirm.CodeiVerification) + string.Format(mailsetting.Description, confirm.CodeiVerification));
        }
        public async Task<Account> GenerateAccount(Request_Register request_Register)
        {
            MailSetting mailSetting = await _baseRepositoryMailsetting.GetAsync(reocrd => reocrd.Code == EmailCode.XacThucDangKy);
            return new Account
            {
                Date_Create = DateTime.Now,
                Full_Name = ToFirstUpper(request_Register.Full_Name),
                User_Name = request_Register.User_Name,
                PassWord = BCryptNet.HashPassword(request_Register.NewPassword),
                Phone_Number = request_Register.Phone_Number,
                Email = request_Register.Email,
                IsConfirm = DateTime.Now.AddDays(1),
                Decentralizations = new List<Decentralization>
                {
                    new Decentralization
                    {
                        role = RoleType.Guest,
                        RoleID = Convert.ToInt64(RoleType.Guest)
                    }
                },
                Cart = GenerateCart(),
                ConfirmEmail = MailSeeding.NewConfirmEmail(mailSetting, null),
                Work = false
            };
        }
        //public static int GenerateCode()
        //{
        //    Random rnd = new Random();
        //    return rnd.Next(100000, 999999);
        //}
        public async Task<DataResponseToken> RenewToken(string token)
        {
            var refeshtoken = await _baseRepositoryRefesh.GetAsync(x => x.Token == token && x.Date_Expired >= DateTime.Now);
            if (refeshtoken == null)
                return new DataResponseToken()
                {
                    AccessToken = "",
                    RefreshToken = ""
                };
            else
            {
                var Account = await _baseRepositoryAccount.GetAsync(x => x.ID == refeshtoken.Account.ID);
                return await GenenrateRquestToken(Account);
            }
        }

        public async Task<DataResponCode> ConfirmCode(string UserName, string code)
        {
            var account = await _baseRepositoryAccount.GetAsync(record => record.User_Name == UserName && record.Deleted == false);
            var Confirm = await _baseRepositoryConfirm.GetAsync(record => record.Account.ID == account.ID && record.IsConfirmed == false && record.Expired >= DateTime.Now && record.Deleted == false);
            if (Confirm == null) return new DataResponCode { Status = StatusCodes.Status404NotFound, Message = CodeVerification.Message_404_code };
            else
            {
                if (Confirm.CodeiVerification == int.Parse(code).ToString())
                {
                    account.Work = true;
                    Confirm.IsConfirmed = true;
                    await _baseRepositoryAccount.UpdateAsync(account);
                    await _baseRepositoryConfirm.UpdateAsync(Confirm);
                    return new DataResponCode
                    {
                        Status = StatusCodes.Status200OK,
                        Message = SUCCESS
                    };
                }
                else
                {
                    return new DataResponCode
                    {
                        Status = StatusCodes.Status408RequestTimeout,
                        Message = CodeVerification.Message_408_code
                    };
                }
            }
        }
        public async Task<DataResponCode> Create_Code(string UserName)
        {
            var mailSetting = await _baseRepositoryMailsetting.GetAsync(record => record.Code == EmailCode.XacThucDangKy);
            var account = await _baseRepositoryAccount.GetAsync(record => record.User_Name == UserName && record.Deleted == false);
            var confirm = _appDbContext.ConfirmEmail.Where(record => record.Account.ID == account.ID);
            if (confirm != null)
            {
                foreach (var item in confirm)
                {
                    item.Deleted = true;
                }
                await _baseRepositoryConfirm.UpdateAsync(confirm);
            }
            account.ConfirmEmail = MailSeeding.NewConfirmEmail(mailSetting, null);
            _appDbContext.SaveChanges();
            if (account == null) return new DataResponCode
            {
                Status = StatusCodes.Status404NotFound,
                Message = CodeVerification.Message_404_Account
            };
            else await SenderEmail(account);
            return new DataResponCode
            {
                Status = StatusCodes.Status200OK,
                Message = SUCCESS
            };
        }
    }
}
