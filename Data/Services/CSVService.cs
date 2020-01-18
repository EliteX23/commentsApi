using Core;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Data.Services
{
   
    public class CSVService : ICSVService
    {
        const string separator = ",";
        //По умолчанию считаем, что разделитель запятая
        public byte[] ConvertToCSV(IEnumerable<Comment> commentList)
        {
            Type t = typeof(Comment);
            FieldInfo[] fields = t.GetFields();

            string header = String.Join(separator, fields.Select(f => f.Name).ToArray());

            StringBuilder csvdata = new StringBuilder();
            csvdata.AppendLine(header);

            foreach (var o in commentList)
                csvdata.AppendLine(ToCsvFields(separator, fields, o));

            byte[] bytesFromBuilder = Encoding.UTF8.GetBytes(csvdata.ToString());
            return bytesFromBuilder;
        }
        private static string ToCsvFields(string separator, FieldInfo[] fields, object o)
        {
            StringBuilder linie = new StringBuilder();

            foreach (var f in fields)
            {
                if (linie.Length > 0)
                    linie.Append(separator);

                var x = f.GetValue(o);

                if (x != null)
                    linie.Append(x.ToString());
            }

            return linie.ToString();
        }
    }
}
