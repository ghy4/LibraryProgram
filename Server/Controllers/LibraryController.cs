using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Server.DTOModels;
using Database.Services;
using Database.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AutoMapper;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _services;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryService sevice, IMapper mapper)
        {
            _services = sevice;
            _mapper = mapper;
        }

        // GET: api/Libraries
        [Route("Libraries")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibraryDTO>>> GetLibraries()
        {
            var libraries = _mapper.Map<IEnumerable<Library>, IEnumerable<LibraryDTO>>(await _services.GetAll());
            return Ok(libraries);
        }

        // GET: api/Library/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryDTO>> GetLibrary(int id)
        {
            var library = await _services.GetById(id);
            if (library == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<Library, LibraryDTO>(library);

            return dto;
        }

        // PUT: api/Library/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(int id, UpdateLibraryDTO library)
        {
            if(id != library.Id)
                return BadRequest();
			try
			{
                await _services.Update(_mapper.Map<Library>(library));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LibraryExists(id))
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

        // POST: api/Library
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostLibrary(CreateLibraryDTO dto)
        {
            var library = _mapper.Map<Library>(dto);
			if (!await _services.Create(library))
				return Problem("Couldn`t add library");
			return StatusCode(201);
        }

        // DELETE: api/Library/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
			var libraries = await _services.GetAll();
			if (libraries == null)
			{
				return NotFound();
			}
			if (await _services.GetById(id) == null)
			{
				return NotFound();
			}

			await _services.RemoveById(id);

			return NoContent();
		}

        private bool LibraryExists(int id)
        {
            return (_services.GetById(id) != null);
        }
    }
}
