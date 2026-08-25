using Microsoft.AspNetCore.Http;

namespace Domain.RepositoryInterfaces
{
    public interface IFileStorage
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
        void DeleteFile(string fileUrl);
    }
}
