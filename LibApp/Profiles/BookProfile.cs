using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;

namespace LibApp.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dto => dto.Genre, opt => opt.MapFrom(book => book.Genre));

            CreateMap<BookDto, Book>()
                .ForMember(book => book.Genre, opt => opt.Ignore()) // Assuming you manage Genre separately and only need GenreId from the DTO
                .ForMember(book => book.DateAdded, opt => opt.Ignore()); // DateAdded is likely set only upon creation and not updated through DTO
        }
    }
}