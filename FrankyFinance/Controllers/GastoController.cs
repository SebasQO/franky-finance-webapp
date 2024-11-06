using FrankyFinance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrankyFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GastoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        // GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGasto()
        {
            return await _appDbContext.Gastos.ToListAsync();
        }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gasto>> GetExpense(int id)
        {
            var expense = await _appDbContext.Gastos.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return expense;
        }

        // POST: api/Expense
        [HttpPost]
        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            _appDbContext.Gastos.Add(gasto);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpense), new { id = gasto.Id }, gasto);
        }

        // PUT: api/Expense/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGasto(int id, Gasto gasto)
        {
            if (id != gasto.Id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(gasto).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasto(int id)
        {
            var expense = await _appDbContext.Gastos.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _appDbContext.Gastos.Remove(expense);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
