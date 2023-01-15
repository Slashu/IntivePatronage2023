using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class LibraryService
{
    private readonly LibraryContext _context;
    public LibraryService(LibraryContext context)
    {
        _context = context;
    }

    public Book? Create(Book newBook)
    {
        _context.Books.Add(newBook);
        _context.SaveChanges();

        return newBook;
    }

    public Author? Create(Author newAuthor)
    {
        _context.Authors.Add(newAuthor);
        _context.SaveChanges();

        return newAuthor;
    }


    public IEnumerable<Book> GetAllBooks()
    {
        return _context.Books.ToList();
    }

    public IEnumerable<Author> GetAllAuthors()
    {
        return _context.Authors.ToList();
    }

    public Book? GetById(int id)
    {
        return _context.Books.SingleOrDefault(b => b.Id == id);
    }


    public IEnumerable<Author> GetAuthorByName(string FirstName)
    {

        return _context.Authors.Where(a => a.FirstName == FirstName).ToList();
    }

    public void UpdateBook(int bookId, string Title, string Description, decimal Rating, string ISBN, DateTime PublicationDate)
    {
        var bookToUpdate = _context.Books.Find(bookId);
        if (bookToUpdate == null)
        {
            throw new InvalidOperationException("Book does not exist");
        }

        bookToUpdate.Title = Title;
        bookToUpdate.Description = Description;
        bookToUpdate.Rating = Rating;
        bookToUpdate.PublicationDate = PublicationDate;
        bookToUpdate.ISBN = ISBN;

        _context.SaveChanges();

    }

    public void DeleteBook(int id)
    {
        var bookToDelete = _context.Books.Find(id);
        if (bookToDelete != null)
        {
            _context.Books.Remove(bookToDelete);
            _context.SaveChanges();
        }
    }

    //SearchBook (By what?)
}