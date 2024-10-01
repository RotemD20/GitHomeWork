using Book.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Interfaces
{
    public interface IBookGitService
    {
        public List<BooksGitDTO> GetBooksGits();
        public BooksGitDTO GetBookById(int bookId);
        public Task<int> CreateBooksGit(BooksGitDTO booksGit);
        public Task<BooksGitDTO> UpdateBooks(BooksGitDTO booksGit);
        public Task DeleteBooksGit(int bookId);

    }
}
