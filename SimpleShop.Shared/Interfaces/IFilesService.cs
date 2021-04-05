using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Shared.Interfaces
{
    public interface IFilesService
    {
        public string GetFileUrl (string fileName);
        public Task SaveFileAsync (Stream mediaBinaryStream, string fileName);
        public Task DeleteFileAsync (string fileName);
        public Task<string> SaveFilePath (IFormFile file);
    }
}
