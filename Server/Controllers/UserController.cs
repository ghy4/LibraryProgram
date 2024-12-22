using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Database.Services;
using Database.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Org.BouncyCastle.Asn1.X509;
using AutoMapper;
using Server.DTOModels;
using NuGet.LibraryModel;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _services;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _services = service;
			_mapper = mapper;
		}

        // GET: api/Users
        [Route("Users")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = _mapper.Map<IEnumerable<UserDTO>>(await _services.GetAll());
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _services.GetById(id);
            if (user == null)
                return NotFound();
            var dto = _mapper.Map<UserDTO>(user);

			return Ok(dto);
        }
        [HttpGet("email")]
        public async Task<ActionResult<UserDTO>>GetUserByEmail(string email)
        {
            var users = await _services.GetAll(); 
            var user = users.FirstOrDefault(x => x.Email == email);
			if (user == null)
				return NotFound();

			var dto = _mapper.Map<UserDTO>(user);
			return Ok(dto);
		}
        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
			if (id != user.Id)
				return BadRequest();
			try
            {
				await _services.Update(_mapper.Map<User>(user));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostUser(CreateUserDTO user)
        {
            if (!await _services.Create(_mapper.Map<User>(user)))
                return Problem("Couldn`t add user");
            return StatusCode(201);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await _services.GetAll();
            if (users == null)
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
        private bool UserExists(int id)
        {
            return (_services.GetById(id) != null);
        }
    }
}
