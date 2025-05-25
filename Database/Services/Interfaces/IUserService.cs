using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        public Task<ICollection<Review>?> GetReviewsAsync(int id);
        public Task<User?> GetByEmail(string email);
        public Task<bool> AddReviewAsync(int userId, int bookId, decimal rating, string reviewText);

	}
}
