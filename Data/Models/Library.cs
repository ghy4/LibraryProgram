using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
	public class Library
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		[JsonIgnore]
		public ICollection<Book>? Books { get; set; }
		public string ContactNumber { get; set; } = string.Empty;
	}
}
