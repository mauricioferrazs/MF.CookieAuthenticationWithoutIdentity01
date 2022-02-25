using System.ComponentModel.DataAnnotations;

namespace MF.CookieAuthenticationWithoutIdentity01.Mvc.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
