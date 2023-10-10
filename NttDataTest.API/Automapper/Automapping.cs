using AutoMapper;
using NttDataTest.MODELS.DTOs;
using NttDataTest.MODELS.Entities;

namespace NttDataTest.API.Automapper
{
    public class Automapping : Profile
    {
        public Automapping() 
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
        }
    }
}
