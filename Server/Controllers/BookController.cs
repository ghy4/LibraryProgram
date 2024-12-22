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
using AutoMapper;
using Database.Services.Interfaces;
using NuGet.LibraryModel;
using Humanizer;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
		private readonly IBookService _services;
		private readonly IMapper _mapper;

		public BookController(IBookService services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        // GET: api/Book
        [Route("Books")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
			var books = _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(await _services.GetAll());
			return Ok(books);
		}

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
			var book = await _services.GetById(id);
			if (book == null)
			{
				return NotFound();
			}
			var dto = _mapper.Map<Book, BookDTO>(book);

			return Ok(dto);
		}
		[HttpGet("Reviews/{bookid}")]
		public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews(int bookid)
		{
			var dto = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDTO>>(await _services.GetBookReviewsAsync(bookid));
			return Ok(dto);
		}

		// PUT: api/Book/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDTO book)
        {
			if (id != book.Id)
				return BadRequest();
			try
			{
				Ok(await _services.Update(_mapper.Map<Book>(book)));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookExists(id))
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

		[Route("AddReview")]
		[HttpPatch]
		public async Task<ActionResult> AddReview(int bookid, CreateReviewDTO newreview)
		{
			var book = _services.GetById(bookid);
			if (book == null) 
				return BadRequest();
			if (bookid != newreview.BookId)
				return BadRequest();
			try
			{
				Ok(await _services.AddReview(_mapper.Map<Review>(newreview)));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookExists(bookid))
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


        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBook(CreateBookDTO dto)
        {
			var book = _mapper.Map<Book>(dto);
			if (!await _services.Create(book))
				return Problem("Couldn`t add library");
			return StatusCode(201);
		}

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
			var books = await _services.GetAll();
			if (books == null)
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

        private bool BookExists(int id)
        {
            return (_services.GetById(id) != null);
        }
    }
}
