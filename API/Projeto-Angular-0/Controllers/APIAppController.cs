using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIApp.Data;
using APIApp.Model;

namespace APIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIAppController : ControllerBase
    {
        private readonly APIAppContext _context;

        public APIAppController(APIAppContext context)
        {
            _context = context;
        }

    // GET: api/Aluno
    [AllowAnonymous]
    [HttpGet]
        public async Task<ActionResult<IEnumerable<Obigeto>>> getAllAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }

    // GET: api/Aluno/5
    [AllowAnonymous]
    [HttpGet("{id}")]
        public async Task<ActionResult<Obigeto>> getAlunoById(int id)
        {
            var Aluno = await _context.Aluno.FindAsync(id);

            if (Aluno == null)
            {
                return NotFound();
            }

            return Aluno;
        }

    // PUT: api/Aluno/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [AllowAnonymous]
    [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Obigeto Aluno)
        {
            if (id != Aluno.alunoId)
            {
                return BadRequest();
            }

            _context.Entry(Aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    // POST: api/Aluno
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [AllowAnonymous]
    [HttpPost]
        public async Task<ActionResult<Obigeto>> createAluno(Obigeto Aluno)
        {
            _context.Aluno.Add(Aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = Aluno.alunoId }, Aluno);
        }

    // DELETE: api/Aluno/5
    [AllowAnonymous]
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var Aluno = await _context.Aluno.FindAsync(id);
            if (Aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(Aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.alunoId == id);
        }
    }
}
