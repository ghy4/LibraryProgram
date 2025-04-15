using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services.Interfaces
{
    public interface ILibraryService : IService<Library>
    {
        public Task<ICollection<Book>?> GetBooks(int libraryid);
        public Task<bool> AddBookToLibraryAsync(int libraryid, int bookid);
    }
}
