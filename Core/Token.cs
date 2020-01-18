using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Token
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]       
        public string Id { get; set; }
        //Практически баг. Поле ключ не уникальное. Следовательно может иметь разные значения, но так как имеется ввиду, что уникальность контролируется человеком
        public string Key { get; set; }
        //для простоты разрешенные типы будут храниться через запятую
        public string GrantedRequest { get; set; }
        public bool IsActive { get; set; }
    }
}
