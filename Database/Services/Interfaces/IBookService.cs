using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services.Interfaces
{
    public interface IBookService : IService<Book>
    {
        public Task<ICollection<Review>> GetBookReviewsAsync(int id);
        public Task<bool> AddReview(Review newreview);
    }
}
