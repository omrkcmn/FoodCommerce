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
    public class RestourantController : ControllerBase
    {
        IRestourantService _restourantService;

        public RestourantController(IRestourantService restourantService)
        {
            _restourantService = restourantService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _restourantService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbyid")]
        public IActionResult GetAllById(int id)
        {
            var result = _restourantService.GetAllById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addres")]
        public IActionResult AddCar(Restourant restourant)
        {
            var result = _restourantService.Add(restourant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateres")]
        public IActionResult UpdateCar(Restourant restourant)
        {
            var result = _restourantService.Update(restourant);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deleteres")]
        public IActionResult DeleteCar(Restourant restourant)
        {
            var result = _restourantService.Delete(restourant);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
