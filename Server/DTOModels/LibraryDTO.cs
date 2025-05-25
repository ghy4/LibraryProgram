using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Server.DTOModels
{
	public class LibraryDTO : UpdateLibraryDTO
	{
		public ICollection<BookDTO>? Books { get; set; }
		public override string ToString() => Name;
	}
	public class CreateLibraryDTO
	{
		[StringLength(25)]
		[Required]
		public string Name { get; set; } = string.Empty;
		[StringLength(150)]
		[Required]
		public string Address { get; set; } = string.Empty;
		[StringLength(15, MinimumLength = 8)]
		[Required]
		public string ContactNumber { get; set; } = string.Empty;
	}
	public class UpdateLibraryDTO : CreateLibraryDTO
	{
		[Required]
		public int Id { get; set; }
	}
}
