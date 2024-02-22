using Microsoft.Extensions.DependencyInjection;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Repository;
using QLBH.Commons.Responces;
using static QLBH.Commons.MailHepper;
using static QLBH.Commons.ImageHepper;
using QLBH.Business.CMS;
using QLBH.Commons;

namespace QLBH.Business
{
    public static class Bootstrap
    {
        public static void DependencyServices(this IServiceCollection services)
        {
            services.AddScoped<UploadImages>();
            services.AddScoped<EmailSender>();
            services.AddScoped<MailSender>();
            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddScoped<IAuthServices, AuthServices>();
            #region CMS
            services.AddScoped<IProductServices<DataResponse_Product, int>, ProductServices>();
            services.AddScoped<IAddressReceive<Respon_AddressReceive, long>, AddressReceiveServices>();
            services.AddScoped<IBillServices, BillServices>();
            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<ICommentProduct<DataRequest_CommentProduct>, CommentProductServices>();
            services.AddScoped<IConfirmEmail, ConfirmEmailServices>();
            services.AddScoped<IDecentralizationServices, DecenlizationServices>();
            services.AddScoped<IDetailCartServices, DetailCartServices>();
            services.AddScoped<IDetailProductServices, DetailProductServices>();
            services.AddScoped<IFeedbackServices<Response_Feedback>, FeedbackProduct>();
            services.AddScoped<IimageProducts<Respon_ImageProduct, long>, ImageProductServices>();
            //services.AddScoped<IFeedbackServices, FeedbackServices>();
            services.AddScoped<IConfirmEmail, ConfirmEmailServices>();
            services.AddScoped<IimageCommentServices<DataRespon_ImageComment, long>, ImageCommentServices>();
            services.AddScoped<IInvoiceDetailsServices, InvoiceDetailsServices>();
            services.AddScoped<IMailSettingServices, MailSettingServices>();
            services.AddScoped<INotificationServices, NotificationServices>();
            services.AddScoped<IProductCategoryServices, ProductCategoryServices>();
            services.AddScoped<IRefeshTokenServices, RefeshTokenServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IStatusBillsServices, StatusBillsServices>();
            services.AddScoped<ITypeProductServices, TypeProductServices>();
            services.AddScoped<IVoucherServices, VoucherServices>();
            #endregion CMS
            RegisterRepositoryDependencies(services);
            ResponcesObjectDependencies(services);
        }
        private static void RegisterRepositoryDependencies(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Account>>(service => new BaseRepository<Account>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Address_Receive>>(service => new BaseRepository<Address_Receive>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Bill>>(service => new BaseRepository<Bill>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Cart>>(service => new BaseRepository<Cart>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<ConfirmEmail>>(service => new BaseRepository<ConfirmEmail>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Decentralization>>(service => new BaseRepository<Decentralization>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Details>>(service => new BaseRepository<Details>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Detail_Cart>>(service => new BaseRepository<Detail_Cart>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<FeedBack>>(service => new BaseRepository<FeedBack>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<ImageProduct>>(service => new BaseRepository<ImageProduct>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Invoice_Details>>(service => new BaseRepository<Invoice_Details>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<MailSetting>>(service => new BaseRepository<MailSetting>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Notification>>(service => new BaseRepository<Notification>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Product>>(service => new BaseRepository<Product>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<ProductCategory>>(service => new BaseRepository<ProductCategory>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<RefeshToken>>(service => new BaseRepository<RefeshToken>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Role>>(service => new BaseRepository<Role>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Status_Bill>>(service => new BaseRepository<Status_Bill>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Type_Product>>(service => new BaseRepository<Type_Product>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Voucher>>(service => new BaseRepository<Voucher>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Comment_Product>>(service => new BaseRepository<Comment_Product>(service.GetService<IAppDbContext>()));
            services.AddScoped<IBaseRepository<Image_Comment>>(service => new BaseRepository<Image_Comment>(service.GetService<IAppDbContext>()));
        }
        private static void ResponcesObjectDependencies(IServiceCollection services)
        {
            services.AddScoped<ResponcesObject<DataResponse_Product>>();
            services.AddSingleton<ResponcesObject<DataRespon_CommentProduct>>();
            services.AddScoped<ResponcesObject<DataResponseToken>>();
        }
    }
}
