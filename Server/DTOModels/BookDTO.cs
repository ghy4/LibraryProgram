using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Server.DTOModels
{
	public class BookDTO : UpdateBookDTO
	{
		public decimal? Rating { get => (Reviews != null && Reviews.Any()) ? Reviews?.Average(x => x.Rating) : null; }
		public ICollection<Library>? Libraries { get; set; }
		public ICollection<Review>? Reviews { get; set; }
	}
	public class CreateBookDTO
	{
		[StringLength(30)]
		[Required]
		public string Title { get; set; } = string.Empty;
		[StringLength(30)]
		[Required]
		public string Author { get; set; } = string.Empty;
		[DataType(DataType.DateTime)]
		[Required]
		public DateTime DateOfPublication { get; set; } = DateTime.MinValue;
		[StringLength(150)]
		[Required] 
		public string Description { get; set; } = string.Empty;
	}
	public class UpdateBookDTO : CreateBookDTO
	{
		[Required]
		public int Id {  get; set; }
	}
}
