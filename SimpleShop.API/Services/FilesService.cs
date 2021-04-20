using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SimpleShop.API.Constant;
using SimpleShop.Shared.Interfaces;

namespace SimpleShop.API.Services
{
    public class FilesService : IFilesService
    {
        private readonly string _userContentFolder;

        public FilesService (IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, FilePath.USER_IMAGES_PATH);
        }

        //Mốt lấy từ UI thì dùng hàm này 
        public string GetFileUrl (string fileName)
        {
            return $" {Startup.clientUrls["Swagger"]}/{FilePath.USER_IMAGES_PATH}/{fileName}";
        }

        public async Task SaveFileAsync (Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync (string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public async Task<string> SaveFilePath (IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await SaveFileAsync(file.OpenReadStream(), fileName);
            return GetFileUrl(fileName);
        }
    }
}


