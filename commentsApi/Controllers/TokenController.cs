using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace commentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IToken _tokenService;
        public TokenController(IToken tokenService)
        {
            _tokenService = tokenService;
        }
       
        [HttpGet("{id}", Name = "GetToken")]
        public  ActionResult<Token> Get(string id)
        {
            var comment = _tokenService.GetApiKey(id);
            comment.Wait();
            if (comment == null)
            {
                return NotFound();
            }

            return comment.Result;
        }

        [HttpPost]
        public ActionResult<Token> Create(Token token)
        {
            _tokenService.Save(token);

            return CreatedAtRoute("GetToken", new { id = token.Key.ToString() }, token);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var comment = _tokenService.GetApiKey(id);
            var result = comment.Result;
            if (result == null)
            {
                return NotFound();
            }

            _tokenService.Delete(result.Key);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Token tokenIn)
        {
            var book = _tokenService.GetApiKey(id);

            if (book == null)
            {
                return NotFound();
            }

            _tokenService.Update(id, tokenIn);

            return NoContent();
        }
    }
}