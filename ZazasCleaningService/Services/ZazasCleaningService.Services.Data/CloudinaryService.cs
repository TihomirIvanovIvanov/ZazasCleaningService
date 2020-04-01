namespace ZazasCleaningService.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService : ICloudinaryService
    {
        private const string ProductImageFolderName = "zazas_cleaning_service_product_image";

        private readonly Cloudinary cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        public async Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName)
        {
            byte[] destinationData;
            using var ms = new MemoryStream();
            // TODO: Null exception
            await pictureFile.CopyToAsync(ms);
            destinationData = ms.ToArray();

            UploadResult uploadResult = null;

            using var memoryStream = new MemoryStream(destinationData);
            var uploadParams = new ImageUploadParams
            {
                Folder = ProductImageFolderName,
                File = new FileDescription(fileName, memoryStream),
            };

            uploadResult = await this.cloudinary.UploadAsync(uploadParams);
            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
