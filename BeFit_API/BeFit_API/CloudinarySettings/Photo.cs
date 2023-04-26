using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace BeFit_API.CloudinarySettings
{
    public class Photo : IPhoto
    {
        public IConfiguration Configuration { get; }
        private CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;

        public Photo(IConfiguration configuration)
        {
            Configuration = configuration;
            _cloudinarySettings = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey,
                _cloudinarySettings.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
        }


        public async Task<string> UploadPhoto(IFormFile file)
        {
            var uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
            });

            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
