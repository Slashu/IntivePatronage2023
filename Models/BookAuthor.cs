using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class BookAuthor
    {
        [NotNull]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [NotNull]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
