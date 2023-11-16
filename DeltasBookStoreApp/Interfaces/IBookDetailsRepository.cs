
using DeltasBookStoreApp.Models;

namespace DeltasBookStoreApp.Interfaces
{
    public interface IBookDetailsRepository
    {
        List<BookDetails> GetBookDetails(string IsActive = "Y");
        BookDetails GetBookDetails(int Id);
        int PutBookDetails(BookDetails bookDetails);
        int PostBookDetails(BookDetails bookDetails);
        int DeleteBookDetails(int Id);

        List<UserDetails> GetUserDetails(UserDetails userDetails);
    }
}
