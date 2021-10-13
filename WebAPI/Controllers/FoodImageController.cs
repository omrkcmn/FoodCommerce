using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FoodImageController : ControllerBase
    {

        IFoodImageService _foodImageService;


        public FoodImageController(IFoodImageService foodImageService)
        {
            _foodImageService = foodImageService;
        }

        [HttpGet("getimagebyfoodid")]
        public IActionResult GetImageByFoodId(int foodId)
        {
            var result = _foodImageService.GetByFoodId(foodId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallimages")]

        public IActionResult GetAll()
        {
            var result = _foodImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[SecuredOperation("admin")]
        [HttpPost("addimage")]

        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] FoodImage foodImage)
        {
            var result = _foodImageService.Add(file, foodImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deleteimage")]

        public IActionResult Delete( FoodImage foodImage)
        {
            var result = _foodImageService.Delete(foodImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateimage")]

        public IActionResult Update(FoodImage foodImage)
        {
            var result = _foodImageService.Update(foodImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
