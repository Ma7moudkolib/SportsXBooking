using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace Infrastructure.Services
{
    public class FileStorageService : IFileStorage
    {
        private readonly IWebHostEnvironment _environment;
        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _environment = webHostEnvironment;
        }
        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {

            var uploadsFolder = Path.Combine(_environment.WebRootPath, folderName);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);


            var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            if (!filePath.StartsWith(_environment.WebRootPath))
            {
                throw new InvalidOperationException("File path is outside the web root.");
            }


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            string ProdUrl = "https://sportsxbooking.runasp.net";
            if (_environment.IsProduction())
            {
                return $"{ProdUrl}/{folderName}/{uniqueFileName}";
            }
            string DevUrl = "http://localhost:5212";
            return $"{DevUrl}/{folderName}/{uniqueFileName}";
        }

        public void DeleteFile(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl))
                return;

            string relativePath = fileUrl;


            if (Uri.TryCreate(fileUrl, UriKind.Absolute, out Uri? uriResult))
            {

                relativePath = uriResult.AbsolutePath;
            }


            var cleanPath = relativePath.TrimStart('/', '\\');


            var filePath = Path.Combine(_environment.WebRootPath, cleanPath);

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"An error occurred while trying to delete the file at {filePath}.", ex);
            }
        }
    }
}
