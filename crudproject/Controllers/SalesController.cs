using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crudproject.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace crudproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesContext _context;

        public SalesController(SalesContext context)
        {
            _context = context;
        }

        // GET: api/Sales1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sales>>> GetSales()
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            Customer c = new();

            return await _context.Sales
                .Include(s => s.Cust)

                .ToListAsync();
        }
        [HttpGet("GetSalesDetails/{id}")]
        public async Task<ActionResult<Sales>> GetSalesDetails(int id)
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            var s =  _context.Sales
               .Include(s => s.Cust)
                // .ThenInclude(customer=>customer.Sales)
               // .Include(s => s.Product)
                 .ThenInclude(product=>product.Sales)
               //.Include(s => s.Store)
                .Where(s => s.Salesid == id)
                .FirstOrDefault();


            if (s == null)
            {
                return NotFound();
            }

            return s;
        }

        // GET: api/Sales1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sales>> GetSales(int id)
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            var sales = await _context.Sales.FindAsync(id);

            if (sales == null)
            {
                return NotFound();
            }

            return sales;
        }

        // PUT: api/Sales1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       // [HttpPut("PutSales/{id}")]

        //public async Task<IActionResult> PutSales(int id, Sales sales)
        //{
        //    if (id != sales.Salesid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(sales).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)

        //    {
        //        throw;
        //    }
        //}

        //    return sales;
        //}
        [HttpPatch]
        [Route("UpdateSales/{id}")]
        public async Task<Sales> UpdateSales(Sales sales)
        {

            _context.Entry(sales).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return sales;
        }

        // POST: api/Sales1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
        /* public async Task<ActionResult<Sales>> PostSales(Sales sales)
         {
             if (_context.Sales == null)
             {
                 return Problem("Entity set 'SalesContext.Sales'  is null.");
             }
            if (sales.Salesid == 0)
            {
                _context.Sales.Add(sales);
                // Console.WriteLine(sales.Salesid);

                await _context.SaveChangesAsync();
            }

             //  return CreatedAtAction("PostSales", new { id = sales.Salesid }, sales);
             return CreatedAtAction(nameof(GetSales), new { id = sales.Salesid }, sales);

             // return (Ok(sales));
            }*/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        public async Task<ActionResult<Sales>> PostSales(Sales sales)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'SalesContext.Sales'  is null.");
            }


           
                _context.Sales.Add(sales);
                // Console.WriteLine(sales.Salesid);

                await _context.SaveChangesAsync();
            

           // return CreatedAtAction("PostSales", new { id = sales.Salesid }, sales);
           return CreatedAtAction(nameof(GetSales), new { id = sales.Salesid }, sales);

            // return (Ok(sales));
        }

        // DELETE: api/Sales1/5
        [HttpDelete("{id}")]
        /* public async Task<IActionResult> DeleteSales(int id)
         {
             if (_context.Sales == null)
             {
                 return NotFound();
             }
             var sales = await _context.Sales.FindAsync(id);
             if (sales == null)
             {
                 return NotFound();
             }

             _context.Sales.Remove(sales);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool SalesExists(int id)
         {
             return (_context.Sales?.Any(e => e.Salesid == id)).GetValueOrDefault();
         }
     }*/
        public bool DeleteSales(int id)
        {
            bool a ;
            var sales = _context.Sales.Find(id);
            if (sales != null)
            {
                a = true;
                _context.Entry(sales).State = EntityState.Deleted;
                _context.SaveChanges();

            }
            else
            {
                a = false;

            }
            return a;

        }

    }
}