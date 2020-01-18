using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Token
    {
        public string Key { get; set; }
        //для простоты разрешенные типы будут храниться через запятую
        public string GrantedRequest { get; set; }
        public bool IsActive { get; set; }
    }
}
