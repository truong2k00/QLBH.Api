using Org.BouncyCastle.Pkcs;
using QLBH.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Commons
{
    public class Common_Constants
    {
        public const string NameSystem = "Quản Lý Bán Hàng";
        public const string FolderSystem = "FolderSystem";
        public const string Email = "aptruong6@gmail.com";
        public const string Hotline = "0981086913";
        public class AppSettingKeys
        {
            public const string DEFAULT_CONTROLER_RAUTER = "api/[controller]";
            public const string AUTH_SECRET = "AppSettings:Secretkey";
            public const string AppSettingGmail = "AppSettings:GmailAccount:Gmail";
            public const string AppSettingGmailPassword = "AppSettings:GmailAccount:PassWord";
            public const string AppSettingSMTP = "AppSettings:GmailAccount:Smtp";
            public const string AppSettingPort = "AppSettings:GmailAccount:Port";
        }
        public class AppSettingJWT
        {
            public const string SchemeName = "Bearer";
            public const string BearerFormat = "JWT";
            public const string Description = "Please enter a valid token";
            public const string Authorization = "Authorization";
        }
        public class AppsettingCloudinary
        {
            public const string CloudinaryName = "AppSettings:AccountCloudinary:CloudName";
            public const string CloudinaryAPIKey = "AppSettings:AccountCloudinary:APIKey";
            public const string CloudinarySecret = "AppSettings:AccountCloudinary:APISecret";
        }
        public class RoleKeyString
        {
            public const string Admin = "Admin";
            public const string User = "User";
            public const string Guest = "Guest";
            public const string Moderator = "Moderator";
            public const string Editor = "Editor";
            public const string Manager = "Manager";
            public const string Superuser = "Superuser";
        }
        public class ContextItem
        {
            public const string USER = "User";
            public const string PERMISSIONS = "Permissions";
        }
        public class CloudUpoad
        {
            public const string Sourc_NewImage = "/xyz-abc_";
            public const string IsNull_IFormFile = "Không Có Tập Tin Được Lựa Chọn.!";
            public class FolderImage
            {
                public const string Folder_Product = "Product";
                public const string Folder_Comment = "Comment";
                public const string Folder_Category = "Category";
            }
        }
        public class SQLRaw
        {
            public const string SET_IDENTITY_INSERT_ON = "SET IDENTITY_INSERT dbo.{0} ON";
            public const string SET_IDENTITY_INSERT_OFF = "SET IDENTITY_INSERT dbo.{0} OFF";
        }
        public class Clames
        {
            public const string ROLES = ClaimTypes.Role;
            public const string USER = "User";
            public const string ID = "ID";
            public const string Email = ClaimTypes.Email;
        }
        public class Handle
        {
            public static string ConLog(Enums.Hepper hepper)
            {
                var str = "";
                switch (hepper)
                {
                    case Enums.Hepper.length:
                        str = "PassWord Độ dài ký tự lớn hơn 8 và nhỏ hơn 14 ký tự";
                        break;
                    case Enums.Hepper.IsUpper:
                        str = "PassWord chứa ký tự A->Z";
                        break;
                    case Enums.Hepper.Islower:
                        str = "PassWord chứa Ký tự a->z";
                        break;
                    case Enums.Hepper.space:
                        str = "PassWord Không được chứa Space";
                        break;
                    case Enums.Hepper.special_character:
                        str = "PassWord Chứa ký tự đặc biệt";
                        break;
                    default:
                        break;
                }
                return str;
            }
        }
        public static string SUCCESS = "success";
        public class Login
        {
            public static string Request_NULL = "vui lòng điền đầy đủ thông tin";
            public static string Error_Pass = "Mật Khẩu Không chính xác.";
            public static string Error_USER_NAME = "Tài Khoản Không đúng.";
        }
        public class Register_Create
        {
            public static string PASSWORD_ERROR = "PassWord Không trùng khớp";
            public static string Phone_ERROR_TYPE = "Số điện thoại không đúng định dạng";
            public static string Phone_ERROR = "Số điện thoại đã đăng ký";
            public static string Error_Email_TYPE = "Email Không đúng định dạng";
            public static string Error_Email = "Email đã đăng ký";
            public static string Error_USER = "Tên Tài Khoản đã tồn tại";
        }
        public class CodeVerification
        {
            public const string Message_404_code = "Mã đã hết hạn vui lòng tạo mã mới.";
            public const string Message_404_Account = "Tài khoản không tồn tại.";
            public const string Message_408_code = "Mã Xác nhận không chính xác";
        }
        public class ErrorExists
        {
            public const string EmptyList = "Does not exist";
            public const string AlreadyExist = "Already Exist";
        }
        public class BaseOperation
        {
            public const string create = "Cannot Create new";
            public const string delete = "Cannot Delete";
            public const string update = "Cannot Update";
        }
    }
}
