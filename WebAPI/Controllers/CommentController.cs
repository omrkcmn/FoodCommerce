using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentservice)
        {
            _commentService = commentservice;
        }

        [HttpGet("getallbyrestid")]
        public IActionResult GetAll(int restourantID)
        {
            var result = _commentService.GetAllByRestId(restourantID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {
            var result = _commentService.Add(comment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
