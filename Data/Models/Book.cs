using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Author { get; set; } = string.Empty;
		public DateTime DateOfPublication { get; set; }
		public string Description { get; set; } = string.Empty;
		public decimal? Rating { get => Reviews?.Average(x => x.Rating); }
		[JsonIgnore]
		public ICollection<Library>? Libraries { get; set;}
		[JsonIgnore]
		public ICollection<Review>? Reviews { get; set; }
	}
}
