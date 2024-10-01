using Book.DAL.DataContext;
using Book.DAL.Entities;
using Book.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DAL.Repositories
{
   public class BooksGitRepository:IBooksGitRepository
    {
        private BooksContext db;

        public BooksGitRepository(BooksContext dbContext)
        {
            db = dbContext;
        }
        public List<BooksGit> GetBooksGits()
        {
            return db.BooksGits.ToList();
        }

        public BooksGit GetBookById(int bookId)
        {
            BooksGit booksGit = db.BooksGits.SingleOrDefault(b => b.BookId == bookId);
            return booksGit;
        }

        public BooksGit GetBookByBookName(string bookName)
        {
            return db.BooksGits.SingleOrDefault(b => b.BookName == bookName);
        }

        public async Task<int> CreateBooksGit(BooksGit booksGit)
        {
            try
            {
                await db.BooksGits.AddAsync(booksGit);
                await db.SaveChangesAsync();
                return booksGit.BookId;
            }
            catch (Exception)
            {
                throw new Exception("no update booksGit");
            }

        }

        public async Task<BooksGit> UpdateBooks(BooksGit booksGit)
        {
            try
            {
                BooksGit ChackBooksGit = await db.BooksGits.AsNoTracking().FirstOrDefaultAsync(b => b.BookId == booksGit.BookId);
                if (ChackBooksGit != null)
                {


                    db.Entry(booksGit).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return booksGit;
            }
            catch (Exception ex)
            {
                throw new Exception("no update BooksGit", ex);
            }
        }

        public async Task DeleteBooksGit(int bookId)
        {
            try
            {
                // חיפוש ההזמנה בבסיס הנתונים לפי ה-ID שלה
                BooksGit booksGit = await db.BooksGits.SingleOrDefaultAsync(b => b.BookId == bookId);

                // בדיקה אם ההזמנה נמצאה
                if (booksGit != null)
                {
                    db.BooksGits.Remove(booksGit);
                    await db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("booksGit not found.");
                }
            }
            catch (Exception ex)
            {
                // טיפול בשגיאה והשלכת שגיאה מותאמת עם מידע נוסף
                throw new Exception("Failed to delete booksGit", ex);
            }
        }
    }
}
