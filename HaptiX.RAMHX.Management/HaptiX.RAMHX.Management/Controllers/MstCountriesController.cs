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
    [Route("api/MstCountries")]
    public class MstCountriesController : Controller
    {
        private readonly RAMHXContext _context;

        public MstCountriesController(RAMHXContext context)
        {
            _context = context;
        }

        // GET: api/MstCountries
        [HttpGet]
        public IEnumerable<MstCountry> GetMstCountry()
        {
            return _context.MstCountry;
        }

        // GET: api/MstCountries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMstCountry([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mstCountry = await _context.MstCountry.SingleOrDefaultAsync(m => m.Id == id);

            if (mstCountry == null)
            {
                return NotFound();
            }

            return Ok(mstCountry);
        }

        // PUT: api/MstCountries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMstCountry([FromRoute] Guid id, [FromBody] MstCountry mstCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mstCountry.Id)
            {
                return BadRequest();
            }

            _context.Entry(mstCountry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MstCountryExists(id))
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

        // POST: api/MstCountries
        [HttpPost]
        public async Task<IActionResult> PostMstCountry([FromBody] MstCountry mstCountry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MstCountry.Add(mstCountry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMstCountry", new { id = mstCountry.Id }, mstCountry);
        }

        // DELETE: api/MstCountries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMstCountry([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mstCountry = await _context.MstCountry.SingleOrDefaultAsync(m => m.Id == id);
            if (mstCountry == null)
            {
                return NotFound();
            }

            _context.MstCountry.Remove(mstCountry);
            await _context.SaveChangesAsync();

            return Ok(mstCountry);
        }

        private bool MstCountryExists(Guid id)
        {
            return _context.MstCountry.Any(e => e.Id == id);
        }
    }
}