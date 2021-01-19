using System.ComponentModel.DataAnnotations;

namespace CIBDigiTechAssessment.MVC.ViewModel
{
    public class CreateUpdatePhoneBookViewModel
    {
        public int PhoneBookID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"$|(^[\d ]*$)", ErrorMessage = "Phone Number can only be numeric value.")]
        public string Contact { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}