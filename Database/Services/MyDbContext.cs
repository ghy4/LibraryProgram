using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
	public class MyDbContext : DbContext
	{
		private readonly string _connectionstring;
		public DbSet<Book> Books { get; set; } 
		public DbSet<User> Users { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Library> Libraries { get; set; }
		public MyDbContext(string connectionstring)
		{
			_connectionstring = connectionstring;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL(_connectionstring);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>()
				.HasMany(b => b.Libraries)
				.WithMany(l => l.Books);
		}
	}
}
