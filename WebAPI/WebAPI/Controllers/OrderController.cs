using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AuthenticationContext _authenticationContext;
        public OrderController(AuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        // GET api/order
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            try
            {
                return _authenticationContext.Orders.AsEnumerable().ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // GET api/order/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                return _authenticationContext.Orders.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // POST api/order
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            try
            {
                _authenticationContext.Orders.Add(order);
                _authenticationContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // PUT api/order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order order)
        {
            try
            {
                Order c = _authenticationContext.Orders.Find(id);
                
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // DELETE api/order/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Order order = _authenticationContext.Orders.Find(id);
                _authenticationContext.Orders.Remove(order);
                _authenticationContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
