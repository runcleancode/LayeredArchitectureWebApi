using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        //Mapping hangi entity ve hangi kopya image i olan dto arasında dönüşüm olacağını belirler.
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>().ReverseMap();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
        }
    }
}
