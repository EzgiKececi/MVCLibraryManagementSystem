using System.ComponentModel.DataAnnotations;

namespace MVCLibraryManagementSystem.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="Doldurulması zorunludur.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Doldurulması zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string PasswordConfirm { get; set; }
    }
}
