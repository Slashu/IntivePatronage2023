using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Author
    {
        [NotNull]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string LastName { get; set; }

        [NotNull]
        public DateTime BirthDate { get; set; }

        [NotNull]
        public bool Gender { get; set; }


    }
}
