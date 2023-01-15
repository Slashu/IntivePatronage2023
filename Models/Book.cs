using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Book
    {
        [NotNull]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Title { get; set; }

        [NotNull]
        [MaxLength()]
        public string Description { get; set; }

        [NotNull]
        public decimal Rating { get; set; }

        [NotNull]
        [MaxLength(13)]
        public string ISBN { get; set; }

        [NotNull]
        public DateTime PublicationDate { get; set; }
    }
}
