using AutoMapper;
using Book.API.Models;
using Book.BL.Interfaces;
using Book.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksGitController : ControllerBase
    {
        private IBookGitService _booksGitService;
        private IMapper _mapper;

        public BooksGitController(IBookGitService booksGitService, IMapper mapper)
        {
            _booksGitService = booksGitService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<BooksGitDTO> GetBooksGits()
        {
            return _booksGitService.GetBooksGits();
        }

        [HttpGet("{id}")]
        public ActionResult<BooksGitDTO> GetBookById(int bookId)
        {
            return Ok(_booksGitService.GetBookById(bookId));
        }

        // הוספת משתמש חדש
        [HttpPost]
        public async Task<int> CreateBooksGit([FromBody] BookRequest booksGit)
        {
            try
            {
                // מיפוי ה-UserRequest ל-UserDTO וקריאה לשירות ליצירת משתמש חדש
                return await _booksGitService.CreateBooksGit(_mapper.Map<BooksGitDTO>(booksGit));
            }
            catch (Exception ex)
            {
                // טיפול בשגיאה והחזרת שגיאה למשתמש
                throw new Exception("Failed to create booksGit", ex);
            }
        }


        // עדכון משתמש
        [HttpPut("{bookId}")]
        public async Task<BooksGitDTO> UpdateBooks(int bookId, [FromBody] BookRequest booksGit)
        {
            try
            {
                // מיפוי ה-UserRequest ל-UserDTO והגדרת ה-userId
                BooksGitDTO newBooksGit = _mapper.Map<BooksGitDTO>(booksGit);
                newBooksGit.BookId = bookId;

                // קריאה לשירות לעדכון המשתמש והחזרת התוצאה
                BooksGitDTO updatedBook = await _booksGitService.UpdateBooks(newBooksGit);
                return updatedBook;
            }
            catch (Exception ex)
            {
                // טיפול בשגיאה והשלכת שגיאה מותאמת
                throw new Exception("Failed to update Book", ex);
            }
        }
        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBooksGit(int bookId)
        {
            try
            {
                await _booksGitService.DeleteBooksGit(bookId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // טיפול בשגיאה והשלכת שגיאה מותאמת עם מידע נוסף
                return StatusCode(500, $"Failed to delete order: {ex.Message}");
            }
        }
    }
}
