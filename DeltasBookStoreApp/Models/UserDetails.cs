using System.ComponentModel.DataAnnotations;

namespace DeltasBookStoreApp.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage = "User Id can't be empty")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Pasword can't be empty")]
        public string Password { get; set; }    
    }
}
