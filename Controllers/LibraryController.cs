using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;


namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]

public class LibraryController : ControllerBase
{
    readonly LibraryService _service;

    public LibraryController(LibraryService service)
    {
        _service = service;
    }

    [HttpGet("getAuthors")]
    public IEnumerable<Author> GetAllAuthors()
    {
        return _service.GetAllAuthors();
    }

    [HttpGet("getBooks")]
    public IEnumerable<Book> GetAllBooks()
    {
        return _service.GetAllBooks();
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = _service.GetById(id);

        if (book is not null)
        {
            return book;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("createAuthor")]
    public IActionResult Create(Author newAuthor)
    {
        var author = _service.Create(newAuthor);
        return CreatedAtAction(nameof(author.Id), new { id = author!.Id }, author);
    }

    [HttpPost("createBook")]
    public IActionResult Create(Book newBook)
    {
        var book = _service.Create(newBook);
        return CreatedAtAction(nameof(book.Id), new { id = book!.Id }, book);
    }

    [HttpGet("getAuthorByName")]
    public IEnumerable<Author> GetAuthorByName(string FirstName)
    {
        return _service.GetAuthorByName(FirstName);
    }

    [HttpPut("updateBook")]
    public IActionResult UpdateBook(int id, string Title, string Description,
        decimal Rating, string ISBN, DateTime PublicationDate)
    {
        var bookToUpdate = _service.GetById(id);
        if (bookToUpdate != null)
        {
            _service.UpdateBook(id, Title, Description, Rating, ISBN, PublicationDate);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}

