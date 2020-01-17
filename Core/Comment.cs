using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Core
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string Author { get; set; }
        public string Topic { get; set; }

    }
}
