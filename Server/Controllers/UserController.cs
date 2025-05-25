using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Services;
using Database.Services;
using Database.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Org.BouncyCastle.Asn1.X509;
using AutoMapper;
using Server.DTOModels;
using NuGet.LibraryModel;
using Org.BouncyCastle.Crypto.Generators;

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
        public async Task<IActionResult> PutUser(int id, [FromBody] UserDTO user)
        {
			if (id != user.Id)
				return BadRequest();

			var existingUser = await _services.GetById(id);
			if (existingUser == null)
				return NotFound();

			try
			{
                _mapper.Map(user, existingUser);
				await _services.Update(existingUser);
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
			user.Password = Encryptor.CreateMD5(user.Password);
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
		[HttpPost("{userId}/review")]
		public async Task<ActionResult> AddReview(int userId, CreateReviewDTO newreview)
		{
			var user = await _services.GetById(userId);
			if (user == null)
				return BadRequest("Invalid user");

			if (newreview.UserId != userId)
				return BadRequest("User ID mismatch");

			try
			{
				var reviewEntity = _mapper.Map<Review>(newreview);

				var result = await _services.AddReviewAsync(userId, newreview.BookId, reviewEntity.Rating, reviewEntity.ReviewText);
				if (!result)
					return BadRequest("Failed to add review");

				return Ok();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(userId))
				{
					return NotFound("User not found");
				}
				else
				{
					throw;
				}
			}
		}
		private bool UserExists(int id)
		{
			return (_services.GetById(id) != null);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
            var users = await _services.GetAll();
			var user = users.FirstOrDefault(u => u.Email == request.Email);

			if (user == null)
				return Unauthorized("Invalid email or password");

			string hashedInputPassword = Encryptor.CreateMD5(request.Password);



			if (hashedInputPassword != user.Password)
				return Unauthorized("Invalid email or password");

			var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

			return Ok(new { Token = token, User = new { user.Id, user.Name, user.Email, user.Role} });
		}
		public class LoginRequest
		{
			public string Email { get; set; }
			public string Password { get; set; }
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequest request)
		{
			var users = await _services.GetAll();
			var existingUser = users.FirstOrDefault(u => u.Email == request.Email);

			if (existingUser != null)
				return BadRequest("Email already in use");

			string hashedPassword = Encryptor.CreateMD5(request.Password);

			var newUser = new User
			{
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				Password = hashedPassword,
				ContactNumber = request.ContactNumber,
                Role = request.Role
			};

			await _services.Create(newUser);

			return Ok(new
			{
				Message = "Registration successful",
				User = new
				{
					newUser.Id,
					newUser.Name,
					newUser.Surname,
					newUser.Email,
					newUser.ContactNumber,
                    newUser.Role
				}
			});
		}

		public class RegisterRequest
		{
			public string Name { get; set; }
			public string Surname { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
			public string ContactNumber { get; set; }
            public string Role { get; set; }
		}
	}
}
