using AutoMapper;
using Data.Models;
using Org.BouncyCastle.Crypto.Utilities;
using Server.DTOModels;

namespace Server.Automapper
{
	public class AutoMapperConfig
	{
		public static MapperConfiguration GetConfiguration()
		{
			return new MapperConfiguration(cfg => {
				cfg.CreateMap<User, UserDTO>();
				cfg.CreateMap<Book, BookDTO>();
				cfg.CreateMap<Library, LibraryDTO>();
				cfg.CreateMap<Review, ReviewDTO>();
				cfg.CreateMap<CreateUserDTO, User>();
				cfg.CreateMap<CreateBookDTO, Book>();
				cfg.CreateMap<UpdateBookDTO, Book>();
				cfg.CreateMap<CreateLibraryDTO, Library>();
				cfg.CreateMap<UpdateLibraryDTO, Library>();
				cfg.CreateMap<CreateReviewDTO, Review>();
				cfg.CreateMap<UpdateReviewDTO, Review>();
			});
		}
	}
}
