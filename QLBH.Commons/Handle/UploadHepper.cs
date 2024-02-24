using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Web;

namespace QLBH.Commons
{
    public class ImageHepper
    {
        public class UploadImages
        {
            private readonly IConfiguration _configuration;
            public Cloudinary _cloudinary;
            public UploadImages(IConfiguration configuration)
            {
                _configuration = configuration;
                _cloudinary = new Cloudinary(new CloudinaryDotNet.Account(_configuration.GetSection(Common_Constants.AppsettingCloudinary.CloudinaryName).Value,
                                                        _configuration.GetSection(Common_Constants.AppsettingCloudinary.CloudinaryAPIKey).Value,
                                                        _configuration.GetSection(Common_Constants.AppsettingCloudinary.CloudinarySecret).Value));
            }

            public async Task<string> UploadImage(string user, IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentNullException(Common_Constants.CloudUpoad.IsNull_IFormFile);
                }
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        PublicId = Common_Constants.CloudUpoad.FolderImage.Folder_Product + "/" +
                        user + Common_Constants.CloudUpoad.Sourc_NewImage
                        + DateTime.Now.Ticks + "image",
                        Transformation = new Transformation().Width(300).Height(400).Crop("fill")
                    };
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    if (uploadResult.Error != null)
                    {
                        throw new Exception(uploadResult.Error.Message);
                    }
                    string imageUrl = uploadResult.SecureUrl.ToString();
                    return imageUrl;
                }
            }
            public string RemoveImage(string Url)
            {
                // Giải mã URL một lần
                Url = HttpUtility.UrlDecode(Url);

                // Mã hóa lại URL một lần

                string stringUrl = Url.Replace("https://res.cloudinary.com/dnitjp0ng/image/upload/v1705602389/", "");
                int index = stringUrl.LastIndexOf('.');
                string publicId = stringUrl.Substring(0, index);

                // Xóa hình ảnh
                DelResParams delParams = new DelResParams
                {
                    PublicIds = new List<string> { publicId }
                };

                DelResResult delResult = _cloudinary.DeleteResources(delParams);

                return delResult.StatusCode.ToString();
            }
        }
    }
}
