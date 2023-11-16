using DeltasBookStoreApp.Interfaces;
using DeltasBookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DeltasBookStoreApp.Controllers
{
    public class BookDetailsController : Controller
    {
        private readonly IBookDetailsRepository _bookDetailsRepository;

        public BookDetailsController(IBookDetailsRepository bookDetailsRepository)
        {
            _bookDetailsRepository = bookDetailsRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<BookDetails> booksList = new List<BookDetails>();
            try
            {
                booksList = _bookDetailsRepository.GetBookDetails();
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured while fetching book details, Please try again later";
            }
            return View(booksList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDetails bookDetails)
        {
            try
            {
                int Result = _bookDetailsRepository.PostBookDetails(bookDetails);
                if (Result == 99)
                {
                    //return Problem("Entity set 'ApplicationDbContext.BookDetails'  is null.");
                    TempData["errorMessage"] = "Book Details Not Got Added. Something went wronge..!";
                }
                else
                {
                    TempData["successMessage"] = "Book Details Added.";
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Saving, Please try again later.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            BookDetails? bookDetails = new BookDetails();
            try
            {
                bookDetails = _bookDetailsRepository.GetBookDetails(Id);
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Fetching, Please try again later.";
                return View();
            }
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult Edit(BookDetails bookDetails)
        {
            try
            {
                int Result;
                Result = _bookDetailsRepository.PutBookDetails(bookDetails);
                if (Result == 99)
                {
                    TempData["errorMessage"] = "Book Details Can't Be Updated.";
                }
                else
                {
                    TempData["successMessage"] = "Book Details Updated.";
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Updating, Please try again later.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            BookDetails? bookDetails = new BookDetails();
            try
            {
                bookDetails = _bookDetailsRepository.GetBookDetails(Id);
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Fetching, Please try again later.";
            }
            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult Delete(BookDetails bookDetails)
        {
            try
            {
                int Result;
                Result = _bookDetailsRepository.DeleteBookDetails(bookDetails.Id);
                if (Result == 99)
                {
                    TempData["errorMessage"] = "Book Details Can't Be Deleted.";
                }
                else
                {
                    TempData["successMessage"] = "Book Details Deleted.";
                }
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured While Deleting, Please try again later.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeletedBooks()
        {
            List<BookDetails>? booksList = new List<BookDetails>();
            try
            {
                booksList = _bookDetailsRepository.GetBookDetails("N");
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Error Occured while fetching book details, Please try again later";
            }
            return View(booksList);
        }
    }
}