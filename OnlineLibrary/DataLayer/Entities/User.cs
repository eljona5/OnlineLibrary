using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibrary.DataLayer.Entities
{
    public class User //: IdentityUser
    {
        //public int ApplicationID { get; set; }

        [Key]
        public int ID { get; set; }
    }
}
