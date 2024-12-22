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
    }
}
