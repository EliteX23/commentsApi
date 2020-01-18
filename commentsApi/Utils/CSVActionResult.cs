using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace commentsApi.Utils
{
    public class CSVActionResult : FileResult
    {
        private string _fileName;
        private byte[] _fileBytes;

        public CSVActionResult(string fileName, byte[] fileBytes)
            : base("text/csv")
        {
            _fileName = fileName;
            _fileBytes = fileBytes;
        }
        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-File-Name");
            context.HttpContext.Response.Headers.Add("X-File-Name", _fileName);
            context.HttpContext.Response.Headers.Add("Content-Type", "text/csv");
            new MemoryStream(_fileBytes).CopyToAsync(context.HttpContext.Response.Body).Wait();
            return base.ExecuteResultAsync(context);
        }
    }
}
