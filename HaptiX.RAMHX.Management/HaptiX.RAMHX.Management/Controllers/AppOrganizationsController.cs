using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HaptiX.RAMHX.Management.Models.DB;

namespace HaptiX.RAMHX.Management.Controllers
{
    [Produces("application/json")]
    [Route("api/AppOrganizations")]
    public class AppOrganizationsController : Controller
    {
        private readonly RAMHXContext _context;

        public AppOrganizationsController(RAMHXContext context)
        {
            _context = context;
        }

        // GET: api/AppOrganizations
        [HttpGet]
        public IEnumerable<AppOrganization> GetAppOrganization()
        {
            return _context.AppOrganization;
        }

        // GET: api/AppOrganizations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppOrganization([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appOrganization = await _context.AppOrganization.SingleOrDefaultAsync(m => m.Id == id);

            if (appOrganization == null)
            {
                return NotFound();
            }

            return Ok(appOrganization);
        }

        // PUT: api/AppOrganizations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppOrganization([FromRoute] Guid id, [FromBody] AppOrganization appOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appOrganization.Id)
            {
                return BadRequest();
            }

            _context.Entry(appOrganization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppOrganizationExists(id))
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

        // POST: api/AppOrganizations
        [HttpPost]
        public async Task<IActionResult> PostAppOrganization([FromBody] AppOrganization appOrganization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppOrganization.Add(appOrganization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppOrganization", new { id = appOrganization.Id }, appOrganization);
        }

        // DELETE: api/AppOrganizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppOrganization([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appOrganization = await _context.AppOrganization.SingleOrDefaultAsync(m => m.Id == id);
            if (appOrganization == null)
            {
                return NotFound();
            }

            _context.AppOrganization.Remove(appOrganization);
            await _context.SaveChangesAsync();

            return Ok(appOrganization);
        }

        private bool AppOrganizationExists(Guid id)
        {
            return _context.AppOrganization.Any(e => e.Id == id);
        }
    }
}