using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private DataAccessContext dbContext;

        public CustomersController()
        {
            string connectionString = "server=localhost;port=3306;database=webapi;uid=root;pwd=thisispassword";
            dbContext = DataAccessContextFactory.Create(connectionString);
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbContext.Customer.ToArray());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = dbContext.Customer.FirstOrDefault(c => c.ID == id);
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromForm]string Name, int Age, string Gender, string Phone, string Email)
        {
            var pre = dbContext.Customer.LastOrDefault();
            var cus = new Customer();
            if (pre == null)
            {
                cus.ID = 1;
            }
            else
            {
                cus.ID = pre.ID + 1;
            }
            cus.Name = Name;
            cus.Age = Age;
            cus.Gender = Gender;
            cus.Phone = Phone;
            cus.Email = Email;
            dbContext.Customer.Add(cus);
            dbContext.SaveChanges();
            return Created("api/customers", cus);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm]string Name, int Age, string Gender, string Phone, string Email)
        {
            var target = dbContext.Customer.SingleOrDefault(c => c.ID == id);
            if (target != null && ModelState.IsValid)
            {
                var changedCus = new Customer();
                changedCus.ID = target.ID;
                changedCus.Name = Name;
                changedCus.Age = Age;
                changedCus.Gender = Gender;
                changedCus.Phone = Phone;
                changedCus.Email = Email;
                dbContext.Entry(target).CurrentValues.SetValues(changedCus);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = dbContext.Customer.SingleOrDefault(c => c.ID == id);
            if (customer != null)
            {
                dbContext.Customer.Remove(customer);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}