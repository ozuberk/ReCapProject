using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{

    public class FileHelperManager : IFileHelper
    {
        public string Add(string path, IFormFile file)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string extension = Path.GetExtension(file.FileName);//dosyanın uzantısı
                string guid = Guid.NewGuid().ToString();// string Guid
                string filePath = guid + extension;//yeni dosya adıve uzantısı.

                using (FileStream fileStream = File.Create(path + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(string path, IFormFile file, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return this.Add(path, file);
        }
    }
}
