using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace commentsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IComment _commentService;
        public CommentController(IComment commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        //не помешает пагинация
        public ActionResult<List<Comment>> Get() =>
            _commentService.GetList().Result.ToList();

        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public ActionResult<Comment> Get(string id)
        {
            var comment = _commentService.GetComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment.Result;
        }

        [HttpPost]
        public ActionResult<Comment> Create(Comment comment)
        {
            _commentService.Save(comment);

            return CreatedAtRoute("GetComment", new { id = comment.Id.ToString() }, comment);
        }
       
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var comment = _commentService.GetComment(id);
            var result = comment.Result;
            if (result == null)
            {
                return NotFound();
            }

            _commentService.Delete(result.Id);

            return NoContent();
        }
        
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Comment commentIn)
        {
            var book = _commentService.GetComment(id);

            if (book == null)
            {
                return NotFound();
            }

            _commentService.Update(id, commentIn);

            return NoContent();
        }
    }
}
