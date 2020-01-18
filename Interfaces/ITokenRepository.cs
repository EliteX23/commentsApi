using Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITokenRepository
    {
        Task<Token> Get(string id);
        //метод предназначен исключительно для заполнения БД.
        Task Save(Token item);
        Task<ReplaceOneResult> Update(string id, Token item);
        Task<DeleteResult> Delete(string id);
    }
}
