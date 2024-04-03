using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Add(string path, IFormFile file);
        string Update(string path, IFormFile file, string filePath);
        void Delete(string filePath);
    }
}
