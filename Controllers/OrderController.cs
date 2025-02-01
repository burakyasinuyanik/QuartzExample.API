using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuartzExample.API.Data;
using QuartzExample.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuartzExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(AppDbContext context) : ControllerBase

    {


      
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return context.Orders;
        }

        

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderDto order)
        {
            Order order1 = new Order();
            order1.Id = order.Id;
            order1.UserId = order.UserId;
            context.Orders.Add(order1);
            context.SaveChanges();
        }

       

       
    }
}
