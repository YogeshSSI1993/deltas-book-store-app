using DeltasBookStoreApp.Context;
using DeltasBookStoreApp.Interfaces;
using DeltasBookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltasBookStoreApp.Implimentation
{
    public class BookDetailsRepository : IBookDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public BookDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BookDetails> GetBookDetails(string IsDeleted)
        {
            return _context.BookDetails.Where(x => x.IsActive == IsDeleted).ToList();
        }

        public BookDetails GetBookDetails(int Id)
        {
            return _context.BookDetails.Find(Id);
        }

        public int PutBookDetails(BookDetails bookDetails)
        {
            if (_context.BookDetails != null)
            {
                _context.Entry(bookDetails).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public int PostBookDetails(BookDetails bookDetails)
        {
            if (_context.BookDetails != null)
            {
                _context.BookDetails.Add(bookDetails);
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public int DeleteBookDetails(int Id)
        {
            if (_context.BookDetails != null)
            {
                var bookDetails = _context.BookDetails.Find(Id);
                bookDetails.IsActive = "N";
                _context.Entry(bookDetails).State = EntityState.Modified;
                return _context.SaveChanges();
            }
            else
            {
                return 99;
            }
        }

        public List<UserDetails> GetUserDetails(UserDetails userDetails)
        {
            return _context.UserDetails.Where(x => x.UserId == userDetails.UserId && x.Password == userDetails.Password).ToList();
        }
    }
}