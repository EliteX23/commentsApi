using Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IComment
    {
        Task<IEnumerable<Comment>> GetList();
        Task<Comment> GetComment(string id);
        Task Save(Comment comment);
        Task Update(string id, Comment item);
        Task Delete(string id);
    }
}
