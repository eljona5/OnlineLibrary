using OnlineLibrary.DataLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.Models
{
    public class AddAuthorModel
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public List<Book>? books { get; set; }
    }
}
