using Core;
using Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class CommentService : IComment
    {
        private ICommentRepository _commentRepo;


        public CommentService(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public async Task Delete(string id)
        {
            await _commentRepo.Delete(id);
        }

        public async Task<Comment> GetComment(string id)
        {
            return await _commentRepo.GetComment(id);
        }

        public async Task<IEnumerable<Comment>> GetList()
        {
            return await _commentRepo.GetCommentList();
        }

        public async Task Save(Comment comment)
        {
            await _commentRepo.Create(comment);
        }

        public async Task Update(string id, Comment comment)
        {
            await _commentRepo.Update(id, comment);
        }
    }
}
