using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICSVService
    {
        byte[] ConvertToCSV(IEnumerable<Comment> commentList);
    }
}
