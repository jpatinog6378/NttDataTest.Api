using AutoMapper;
using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Entities;
using NttDataTest.MODELS.Requests;

namespace NttDataTest.API.Automapper
{
    public class Automapping : Profile
    {
        public Automapping() 
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<AuthorRequest, Author>().ReverseMap();
            CreateMap<AuthorRequest, AuthorDTO>().ReverseMap();

            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<BookRequest, Book>().ReverseMap();
            CreateMap<BookRequest, BookDTO>().ReverseMap();
        }
    }
}
