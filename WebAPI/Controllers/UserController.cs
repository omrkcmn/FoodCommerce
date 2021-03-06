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
    public class UserController : ControllerBase
    {
        IUserService _userservice;

        public UserController(IUserService userService)
        {
            _userservice = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getrestid")]
        public IActionResult GetRestId(int id)
        {
            var result = _userservice.GetREstIdByUserId(id);
            int id2 = result.Data[0].RestoranId;
            if (result.Success)
            {
                return Ok(id2);
            }
            return BadRequest(result);
        }

        [HttpGet("getclaims")]
        public ActionResult GetOperationClaims(int userId)
        {
            var result = _userservice.GetClaims(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetUserById(int id)
        {
            var result = _userservice.GetUserById(id);
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        /*[HttpGet("getbymail")]
        public IActionResult GetUserByMail(string email)
        {
            var result = _userservice.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }*/

        [HttpGet("getuserrentdetail")]
        public IActionResult GetUserRentDetail(int id)
        {
            var result = _userservice.GetCarByRentUserId(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("adduser")]
        public IActionResult AddUser(User user)
        {
            var result = _userservice.Add(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _userservice.Update(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("deleteuser")]
        public IActionResult DeleteBrand(User user)
        {
            var result = _userservice.Delete(user);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
