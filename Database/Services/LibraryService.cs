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
	public class LibraryService : ILibraryService
	{
		private readonly MyDbContext _dbContext;

		public LibraryService(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<bool> Create(Library entity)
		{
			await _dbContext.Libraries.AddAsync(entity);
			return await _dbContext.SaveChangesAsync() >= 1;
		}

		public async Task<ICollection<Library>> GetAll()
		{
			var libraries = await _dbContext.Libraries.Include(b=>b.Books).ToListAsync();
			return libraries;
		}

		public async Task<ICollection<Book>?> GetBooks(int libraryid)
		{
			var library = await _dbContext.Libraries.FirstOrDefaultAsync(x => x.Id == libraryid);
			if(library == null)
				return null;
			return library.Books;
		}

		public async Task<Library?> GetById(int id)
		{
			var library = await _dbContext.Libraries.Include(b=>b.Books).FirstOrDefaultAsync(x => x.Id == id);
			return library;
		}

		public async Task<bool> RemoveById(int id)
		{
			var librarytoremove = await _dbContext.Libraries.FirstOrDefaultAsync(x => x.Id == id);
			if (librarytoremove == null)
				return false;
			_dbContext.Remove(librarytoremove);
			return await _dbContext.SaveChangesAsync() >= 1;
		}

		public async Task<bool> Update(Library entity)
		{
			_dbContext.Libraries.Update(entity);
			return await _dbContext.SaveChangesAsync() >= 1;
		}
	}
}
