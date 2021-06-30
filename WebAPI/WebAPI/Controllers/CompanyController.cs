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
    public class CompanyController : ControllerBase
    {
        private readonly AuthenticationContext _authenticationContext;
        public CompanyController(AuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        // GET api/company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            try
            {
                return _authenticationContext.Companies.AsEnumerable().ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // GET api/company/5
        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            try
            {
                return _authenticationContext.Companies.Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // POST api/company
        [HttpPost]
        public void Post([FromBody] Company company)
        {
            try
            {
                _authenticationContext.Companies.Add(company);
                _authenticationContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // PUT api/company/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company company)
        {
            try
            {
                Company c = _authenticationContext.Companies.Find(id);
                
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        // DELETE api/company/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                Company company = _authenticationContext.Companies.Find(id);
                _authenticationContext.Companies.Remove(company);
                _authenticationContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
