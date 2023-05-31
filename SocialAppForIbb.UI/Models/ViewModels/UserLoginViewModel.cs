using System.ComponentModel.DataAnnotations;

namespace SocialAppForIbb.UI.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string Password { get; set; }
    }
}
