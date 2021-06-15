using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mustafa.Helper
{
    public static class FileHelper
    {
        public static string UploadFileAndGetPath(IFormFile formFile)
        {
            // path to aspnet-core
            var combinePath = Path.Combine("images", DateTime.Now.ToString("yyyy_dd_MM"));
            var pathToSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, combinePath);
            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);
            var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            fileName = DateTime.Now.ToString("yyyymmddMMss") + '-' + fileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(combinePath, fileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return dbPath;
        }
        public static string UploadFileAndGetFullPath(IFormFile formFile)
        {
            // path to aspnet-core
            var combinePath = Path.Combine("images", DateTime.Now.ToString("yyyy_dd_MM"));
            var pathToSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, combinePath);
            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);
            var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
            fileName = DateTime.Now.ToString("yyyymmddMMss") + '-' + fileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return fullPath;
        }
    }
}
