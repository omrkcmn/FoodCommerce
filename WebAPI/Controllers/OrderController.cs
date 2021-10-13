using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int id)
        {
            var result = _orderService.GetAll(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //Burada telefon numarası girilen kişinin verdiği siparişler listelenecek.
        [HttpGet("getorderdetail")]
        
        public IActionResult GetOrderDetail(int userID, bool tamamlama)
        {
            var result = _orderService.GetUserFilteredDetail(userID, tamamlama);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getrestorders")]

        public IActionResult GetRestOrders(int restID, bool tamamlama)
        {
            var result = _orderService.GetRestourantFilteredDetail(restID, tamamlama);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("addorder")]

        public IActionResult AddOrder(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("updateorder")]

        public IActionResult UpdateOrder(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("deleteorder")]
        public IActionResult DeleteOrder(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}