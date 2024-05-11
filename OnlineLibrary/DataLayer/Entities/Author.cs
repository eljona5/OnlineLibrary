using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.DataLayer.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Description { get; set; }
        public virtual List<Book>? Books { get; set; }
        public string? PhotoPath {  get; set; }
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool? IsDelete { get; set; }

    }
}
