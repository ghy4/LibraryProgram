using Data.Models;
using Database.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
	public class BookService : IBookService
	{
		private readonly MyDbContext _dbContext;
		public BookService(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> AddReview(Review newreview)
		{
			newreview.ReviewDate = DateTime.Now;
			await _dbContext.Reviews.AddAsync(newreview);
			return await _dbContext.SaveChangesAsync() >= 1;
		}

		public async Task<bool> Create(Book entity)
		{
			entity.DateOfPublication = DateTime.Now;
			await _dbContext.Books.AddAsync(entity);
			return await _dbContext.SaveChangesAsync() >= 1;
		}

		public async Task<ICollection<Book>> GetAll()
		{
			var books = await _dbContext.Books.Include(b=>b.Reviews).Include(b=>b.Libraries).ToListAsync();
			return books;
		}

		public async Task<Book?> GetById(int id)
		{
			var book = await _dbContext.Books.Include(b =>b.Reviews).Include(b=>b.Libraries).FirstOrDefaultAsync(x => x.Id == id);
			return book;
		}

		public async Task<ICollection<Review>> GetBookReviewsAsync(int bookid)
		{
			var reviews = await _dbContext.Reviews.Include(x=>x.Book).Include(b=>b.User).Where(x => x.BookId == bookid).ToListAsync();
			return reviews;
		}

		public async Task<bool> RemoveById(int id)
		{
			var booktoremove = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
			if (booktoremove == null)
				return false;
			_dbContext.Remove(booktoremove);
			return await _dbContext.SaveChangesAsync() >= 1;
		}

		public async Task<bool> Update(Book entity)
		{
			_dbContext.Books.Update(entity);
			return await _dbContext.SaveChangesAsync() >= 1;
		}
	}
}
