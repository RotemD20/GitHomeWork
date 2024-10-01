using Book.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DAL.Interfaces
{
    public interface IBooksGitRepository
    {
        public List<BooksGit> GetBooksGits();
        public BooksGit GetBookById(int bookId);
        public Task<int> CreateBooksGit(BooksGit booksGit);
        public Task<BooksGit> UpdateBooks(BooksGit booksGit);
        public Task DeleteBooksGit(int bookId);
    }
}
