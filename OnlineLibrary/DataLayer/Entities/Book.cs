using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibrary.DataLayer.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string? PhotoPath { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

    }
}
