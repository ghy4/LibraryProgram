﻿using Data.Models;
using Database.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
	public class UserService : IUserService
	{
		private readonly MyDbContext _dbContext;
		public UserService(MyDbContext dbContext)
		{ 
			_dbContext = dbContext;
		}
		public async Task<bool> Create(User entity)
		{
			await _dbContext.Users.AddAsync(entity);
			return await _dbContext.SaveChangesAsync() >= 1;
		}
		public async Task<ICollection<User>> GetAll()
		{
			var users = await _dbContext.Users.ToListAsync();
			return users;
		}
		public async Task<User?> GetById(int id)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
			return user;
		}
		public async Task<User?> GetByEmail(string email)
		{
			var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
			return user;
		}
		public async Task<ICollection<Review>?> GetReviewsAsync(int id)
		{
			var reviews = await _dbContext.Reviews.Where(x => x.UserId == id).ToListAsync();
			return reviews;
		}
		public async Task<bool> AddReviewAsync(int userId, int bookId, decimal rating, string reviewText)
		{
			var review = new Review
			{
				UserId = userId,
				BookId = bookId,
				Rating = rating,
				ReviewText = reviewText,
				ReviewDate = DateTime.Now
			};

			await _dbContext.Reviews.AddAsync(review);
			var result = await _dbContext.SaveChangesAsync();

			return result >= 1;
		}
		public async Task<bool> RemoveById(int id)
		{
			var usertoremove = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (usertoremove == null)
				return false;
			_dbContext.Remove(usertoremove);
			return await _dbContext.SaveChangesAsync() >= 1;
		}
		public async Task<bool> Update(User entity)
		{
			_dbContext.Users.Attach(entity);
			return await _dbContext.SaveChangesAsync() >= 1;
		}
	}
}
