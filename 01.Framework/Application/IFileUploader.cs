using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Framework.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path);
    }
}
