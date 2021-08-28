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

    // GET: api/APIApp
    [AllowAnonymous]
    [HttpGet]
        public async Task<ActionResult<IEnumerable<APIAppModel>>> getAllAPIApps()
        {
            return await _context.APIApp.ToListAsync();
        }

    // GET: api/APIApp/5
    [AllowAnonymous]
    [HttpGet("{id}")]
        public async Task<ActionResult<APIAppModel>> getAPIAppById(int id)
        {
            var APIApp = await _context.APIApp.FindAsync(id);

            if (APIApp == null)
            {
                return NotFound();
            }

            return APIApp;
        }

    // PUT: api/APIApp/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [AllowAnonymous]
    [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIApp(int id, APIAppModel APIApp)
        {
            if (id != APIApp.APIAppId)
            {
                return BadRequest();
            }

            _context.Entry(APIApp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIAppExists(id))
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

    // POST: api/APIApp
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [AllowAnonymous]
    [HttpPost]
        public async Task<ActionResult<APIAppModel>> createAPIApp(APIAppModel APIApp)
        {
            _context.APIApp.Add(APIApp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAPIApp", new { id = APIApp.APIAppId }, APIApp);
        }

    // DELETE: api/APIApp/5
    [AllowAnonymous]
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIApp(int id)
        {
            var APIApp = await _context.APIApp.FindAsync(id);
            if (APIApp == null)
            {
                return NotFound();
            }

            _context.APIApp.Remove(APIApp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIAppExists(int id)
        {
            return _context.APIApp.Any(e => e.APIAppId == id);
        }
    }
}
