using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USTMLibrary_API.Data;
using USTMLibrary_API.Data.Repositories;
using USTMLibrary_API.model;

namespace USTMLibrary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographiesController : ControllerBase
    {
        private readonly IBibliographyRepository _bibliographyRepository;

        public BibliographiesController(IBibliographyRepository bibliographyRepository)
        {
            _bibliographyRepository = bibliographyRepository;
        }

        // GET: api/Bibliographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bibliography>>> GetBibliography()
        {
            var bibliographies = await _bibliographyRepository.GetAll();
            return Ok(bibliographies);
        }

        // GET: api/Bibliographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bibliography>> GetBibliography(int id)
        {
            var bibliography = await _bibliographyRepository.GetById(id);
            if (bibliography == null)
            {
                return NotFound();
            }
            return bibliography;
        }

        // POST: api/Bibliographies
        [HttpPost]
        public async Task<ActionResult<Bibliography>> PostBibliography(Bibliography bibliography)
        {
            await _bibliographyRepository.Add(bibliography);
            return CreatedAtAction(nameof(GetBibliography), new { id = bibliography.Id }, bibliography);
        }

        // PUT: api/Bibliographies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibliography(int id, Bibliography bibliography)
        {
            if (id != bibliography.Id)
            {
                return BadRequest();
            }

            await _bibliographyRepository.Update(bibliography);
            return NoContent();
        }

        // DELETE: api/Bibliographies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibliography(int id)
        {
            await _bibliographyRepository.Delete(id);
            return NoContent();
        }

    }
}
