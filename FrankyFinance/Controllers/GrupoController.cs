using FrankyFinance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace FrankyFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public GrupoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo>>> GetGrupos()
        {
            return await _appDbContext.Grupos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetGrupo(int id)
        {
            var grupo = await _appDbContext.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            return grupo;
        }

        [HttpPost]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
            _appDbContext.Grupos.Add(grupo);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupo), new { id = grupo.Id }, grupo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(grupo).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            var grupo = await _appDbContext.Grupos.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            _appDbContext.Grupos.Remove(grupo);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
