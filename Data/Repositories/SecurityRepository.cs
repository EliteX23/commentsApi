using Core;
using Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SecurityRepository : ITokenRepository
    {
        private IMongoCollection<Token> _collection;
        public SecurityRepository(Dictionary<string, string> settings)
        {
            var client = new MongoClient(settings["ConnectionString"]);
            var database = client.GetDatabase(settings["DatabaseName"]);
            _collection = database.GetCollection<Token>(settings["ApiCollectionName"]);

        }

        public async Task<DeleteResult> Delete(string id)
        {
            return await _collection.DeleteOneAsync(apiKey => apiKey.Key == id);
        }

        public async Task<Token> Get(string id)
        {
            return await _collection.FindAsync(apiKey => apiKey.Key == id).Result.FirstOrDefaultAsync();
        }

        public async Task Save(Token item)
        {
            await _collection.InsertOneAsync(item);
        }

        public async Task<ReplaceOneResult> Update(string id, Token item)
        {
            return await _collection.ReplaceOneAsync(apiKey => apiKey.Key == id, item);
        }
    }
}
