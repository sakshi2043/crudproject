using crudproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SalesContext _salecontext;
        public CustomerController(SalesContext dbsalecontext)
        { _salecontext = dbsalecontext; }

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            if (_salecontext.Customers == null)
            {
                return NotFound();
            }


            return await _salecontext.Customers.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if (_salecontext.Customers == null)
            {
                return NotFound();
            }
            var customer = await _salecontext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<ActionResult<Customer>> AddCustomers(Customer objcustomer)
        {
            _salecontext.Customers.Add(objcustomer);
            await _salecontext.SaveChangesAsync();
            return CreatedAtAction(nameof(AddCustomers), new { id = objcustomer.CustId }, objcustomer);
            //return objcustomer;
        }
        [HttpPatch]
        [Route("UpdateCustomers/{id}")]
        public async Task<Customer> UpdateCustomers(Customer objcustomer)
        {

            _salecontext.Entry(objcustomer).State = EntityState.Modified;
            try
            {
                await _salecontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return objcustomer;
        }
        [HttpDelete]
        [Route("deletecustomer/{id}")]
        public bool DeleteCustomer(int id)
        {
            bool a = false;
            var customer = _salecontext.Customers.Find(id);
            if (customer != null)
            {
                try
                {
                    a = true;
                    _salecontext.Entry(customer).State = EntityState.Deleted;
                    _salecontext.SaveChanges();
                }
                catch(Exception ) {
                    throw;
                }

            }
            else
            {
                a = false;

            }
            return a;

        }
    }
}
