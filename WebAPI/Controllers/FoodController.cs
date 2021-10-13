using Business.Abstract;
using Core.Aspects.Autofac.Caching;
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
    public class FoodController : ControllerBase
    {
        IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _foodService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllByFoodAndRestName")]
        public IActionResult GetAllByFoodAndRestName(string foodName, string restName)
        {
            var result = _foodService.GetAllByFoodAndRestName(foodName, restName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getfooddetail")]
        public IActionResult GetFoodDetail(int id)
        {
            var result = _foodService.GetAllById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getfoodbyid")]
        public IActionResult GetFoodById(int id)
        {
            var result = _foodService.GetFoodByFoodId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("addfood")]
        public IActionResult Addfood(Food food)
        {
            var result = _foodService.Add(food);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateFood")]
        public IActionResult UpdateFood(Food food)
        {
            var result = _foodService.Update(food);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletefood")]
        public IActionResult DeleteFood(Food food)
        {
            var result = _foodService.Delete(food);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyrestid")]
        public IActionResult GetByRestId(int id)
        {
            var result = _foodService.GetAllByRestourantId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyrestid2")]
        public IActionResult GetByRestId2(int id)
        {
            var result = _foodService.GetAllByRestourantId2(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
