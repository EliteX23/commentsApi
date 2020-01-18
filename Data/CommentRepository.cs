using Core;
using Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class CommentRepository : ICommentRepository
    {
        private IMongoCollection<Comment> _collection;
        public CommentRepository(Dictionary<string, string> settings)
        {
            var client = new MongoClient(settings["ConnectionString"]);
            var database = client.GetDatabase(settings["DatabaseName"]);
            _collection = database.GetCollection<Comment>(settings["CommentCollectionName"]);

        }
        public async Task Create(Comment item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task<DeleteResult> Delete(string id)
        {
            return await _collection.DeleteOneAsync(comment => comment.Id == id);
            //считаем, что удаление прошло, когда запрос подтвержден и кол-во удаленных документов больше 0

        }


        public async Task<Comment> GetComment(string id)
        {
            return await _collection.FindAsync(comment => comment.Id == id).Result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentList()
        {
            return await _collection.FindAsync(book => true).Result.ToListAsync();
        }



        public async Task<ReplaceOneResult> Update(string id, Comment commentIn)
        {
            //можно использовать update, но не указано какие поля можем обновлять, по умолчанию обновляются все
            return await _collection.ReplaceOneAsync(comment => comment.Id == id, commentIn);
        }
    }
}
