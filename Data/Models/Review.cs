using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
	public class Review
	{
		[Key]
		public int Id { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }
		public int BookId { get; set; }
		public Book? Book { get; set; }
		public decimal Rating { get; set; }
		public string ReviewText { get; set; } = string.Empty;
		public DateTime ReviewDate { get; set; }
	}
}
