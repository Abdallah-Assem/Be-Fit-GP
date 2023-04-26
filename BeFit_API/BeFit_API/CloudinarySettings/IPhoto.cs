namespace BeFit_API.CloudinarySettings
{
    public interface IPhoto
    {
        public Task<string> UploadPhoto(IFormFile file);
    }
}
