using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;

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
            public string RemoveImage(string url)
            {
                Uri uri = new Uri(url);
                string path = uri.AbsolutePath;

                // Tách lấy phần cuối của path
                string[] segments = path.Split('/');
                string publicIdWithExtension = segments[segments.Length - 1];

                // Loại bỏ phần mở rộng từ publicId
                int index = publicIdWithExtension.LastIndexOf('.');
                string name = publicIdWithExtension.Substring(0, index);

                DelResParams delParams = new DelResParams
                {
                    PublicIds = new List<string> { name }
                };
                var result = _cloudinary.DeleteResources(delParams);
                return result.StatusCode.ToString();
            }
        }
    }
}
