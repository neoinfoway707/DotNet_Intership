using ProductManagement.Application.Interfaces.Services;

namespace ProductManagement.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
        {
            if (fileStream == null || string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("Invalid file data provided.");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                throw new ArgumentException("Invalid file type. Only images (.jpg, .jpeg, .png, .gif, .webp) are allowed.");
            }

            string baseDir = Directory.GetCurrentDirectory();
            string uploadFloder = Path.Combine(baseDir, "wwwroot", "Uploads", "Products");
            if (!Directory.Exists(uploadFloder))
                Directory.CreateDirectory(uploadFloder);

            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(fileName)}";
            string physiclePath = Path.Combine(uploadFloder, uniqueFileName);

            using (var destinationPath = new FileStream(physiclePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(destinationPath);
            }
            return $"/Uploads/Products/{uniqueFileName}";
        }
    }
}