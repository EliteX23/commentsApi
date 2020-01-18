using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commentsApi.MongoConnection
{
    public class CommentDatabaseSettings : ICommentDatabaseSettings
    {
        public string CommentsCollectionName { get; set; }
        public string ApiCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICommentDatabaseSettings
    {
        string CommentsCollectionName { get; set; }
        string ApiCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
