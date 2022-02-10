using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T3ProjectApplication.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Date of Birth")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public string Gender { get; set; }
    }
}
