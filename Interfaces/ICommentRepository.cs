using Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentList();
        Task<Comment> GetComment(string id);
        Task Create(Comment item);
        Task<ReplaceOneResult> Update(string id, Comment item);
        Task<DeleteResult> Delete(string id);

    }
}
