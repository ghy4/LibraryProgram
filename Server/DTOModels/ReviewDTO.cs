using Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Server.DTOModels
{
	public class ReviewDTO : UpdateReviewDTO
	{
		public User? User { get; set; }
		public Book? Book { get; set; }
	}
	public class CreateReviewDTO
	{
		[Required]
		public int UserId { get; set; }
		[Required]
		public int BookId { get; set; }
		[Range(0d, 5d)]
		[Required]
		public decimal Rating { get; set; }
		[StringLength(150)]
		public string ReviewText { get; set; } = string.Empty;
		[DataType(DataType.DateTime)]
		[Required]
		public DateTime ReviewDate { get; set; } = DateTime.MinValue;
	}
	public class UpdateReviewDTO : CreateReviewDTO
	{
		[Required]
		public int Id { get; set; }
	}
}
