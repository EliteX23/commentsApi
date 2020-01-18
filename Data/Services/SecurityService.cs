using Core;
using Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class SecurityService : IToken
    {
        private ITokenRepository _apiKeyRepo;
        public SecurityService(ITokenRepository apiRepo)
        {
            _apiKeyRepo = apiRepo;
        }

        public async Task Delete(string id)
        {
            await _apiKeyRepo.Delete(id);
        }

        public async Task<Token> GetApiKey(string id)
        {
            return await _apiKeyRepo.Get(id);
        }

        public async Task<bool> IsValid(string apikey, string method)
        {
            var apiKeyEntity = await _apiKeyRepo.Get(apikey);
            if (apiKeyEntity == null || !apiKeyEntity.IsActive)
            {
                return false;
            }
            if (!apiKeyEntity.GrantedRequest.Contains(method))
            {
                return false;
            }
            return true;
        }

        public async Task Save(Token key)
        {
            await _apiKeyRepo.Save(key);
        }

        public async Task Update(string id, Token item)
        {
            await _apiKeyRepo.Update(id, item);
        }
    }
}
