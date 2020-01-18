using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IToken
    {
        Task<bool> IsValid(string apikey, string method);

        //Методы только для теста
        Task<Token> GetApiKey(string id);
        Task Save(Token key);
        Task Update(string id, Token item);
        Task Delete(string id);
    }
}
