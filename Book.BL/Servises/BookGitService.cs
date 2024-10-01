using AutoMapper;
using Book.BL.Interfaces;
using Book.DAL.Entities;
using Book.DAL.Interfaces;
using Book.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Servises
{
    public class BookGitService: IBookGitService
    {
        private IBooksGitRepository _booksRepository;
        private IMapper _mapper;
  
        public BookGitService(IBooksGitRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        //רשימת משתמשים
        public List<BooksGitDTO> GetBooksGits()
        {
            List<BooksGit> result = _booksRepository.GetBooksGits();
            return _mapper.Map<List<BooksGitDTO>>(result);
  
        }
        //GETID
        public BooksGitDTO GetBookById(int bookId)
        {
            BooksGit booksGit = _booksRepository.GetBookById(bookId);
            return _mapper.Map<BooksGitDTO>(bookId);
        }
        //צור משתמש
        public async Task<int> CreateBooksGit(BooksGitDTO booksGit)
        {
            try
            {
                var createBookByid = await _booksRepository.CreateBooksGit(_mapper.Map<BooksGit>(booksGit));
                return createBookByid;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create user");
            }
        }
        // עדכן משתמש
        public async Task<BooksGitDTO> UpdateBooks(BooksGitDTO booksGit)
        {
            try
            {
                BooksGit updateBooks = await _booksRepository.UpdateBooks(_mapper.Map<BooksGit>(booksGit));
                return _mapper.Map<BooksGitDTO>(updateBooks);
            }
            catch (Exception ex)
            {
                {
                    throw new Exception("no update user", ex);
                }
            }
        }
        public async Task DeleteBooksGit(int bookId)
        {
            try
            {
                await _booksRepository.DeleteBooksGit(bookId);
            }
            catch (Exception ex)
            {
                // טיפול בשגיאה והשלכת שגיאה מותאמת עם מידע נוסף
                throw new Exception($"Failed to delete order with ID: {bookId}", ex);
            }
       }
    }
}
