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
    [Route("api/AppOrganizationDepartments")]
    public class AppOrganizationDepartmentsController : Controller
    {
        private readonly RAMHXContext _context;

        public AppOrganizationDepartmentsController(RAMHXContext context)
        {
            _context = context;
        }

        // GET: api/AppOrganizationDepartments
        [HttpGet]
        public IEnumerable<AppOrganizationDepartment> GetAppOrganizationDepartment()
        {
            return _context.AppOrganizationDepartment;
        }

        // GET: api/AppOrganizationDepartments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppOrganizationDepartment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appOrganizationDepartment = await _context.AppOrganizationDepartment.SingleOrDefaultAsync(m => m.Id == id);

            if (appOrganizationDepartment == null)
            {
                return NotFound();
            }

            return Ok(appOrganizationDepartment);
        }

        // PUT: api/AppOrganizationDepartments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppOrganizationDepartment([FromRoute] Guid id, [FromBody] AppOrganizationDepartment appOrganizationDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appOrganizationDepartment.Id)
            {
                return BadRequest();
            }

            _context.Entry(appOrganizationDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppOrganizationDepartmentExists(id))
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

        // POST: api/AppOrganizationDepartments
        [HttpPost]
        public async Task<IActionResult> PostAppOrganizationDepartment([FromBody] AppOrganizationDepartment appOrganizationDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppOrganizationDepartment.Add(appOrganizationDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppOrganizationDepartment", new { id = appOrganizationDepartment.Id }, appOrganizationDepartment);
        }

        // DELETE: api/AppOrganizationDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppOrganizationDepartment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appOrganizationDepartment = await _context.AppOrganizationDepartment.SingleOrDefaultAsync(m => m.Id == id);
            if (appOrganizationDepartment == null)
            {
                return NotFound();
            }

            _context.AppOrganizationDepartment.Remove(appOrganizationDepartment);
            await _context.SaveChangesAsync();

            return Ok(appOrganizationDepartment);
        }

        private bool AppOrganizationDepartmentExists(Guid id)
        {
            return _context.AppOrganizationDepartment.Any(e => e.Id == id);
        }
    }
}