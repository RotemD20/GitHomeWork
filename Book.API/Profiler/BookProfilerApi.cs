using AutoMapper;
using Book.API.Models;
using Book.DAL.Entities;
using Book.DTO.Models;

namespace Book.API.Profiler
{
    public class BookProfilerApi : Profile
    {
        public BookProfilerApi()
        {
            CreateMap<BookRequest, BooksGitDTO>().ReverseMap();
        }
    }
}
