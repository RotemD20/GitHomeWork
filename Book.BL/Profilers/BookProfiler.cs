using AutoMapper;
using Book.DAL.Entities;
using Book.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Profilers
{
    public class BookProfiler: Profile
    {
        public BookProfiler()
        {
            CreateMap<BooksGit, BooksGitDTO>().ReverseMap();
        }
    }
}
