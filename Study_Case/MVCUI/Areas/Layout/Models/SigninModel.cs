using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCUI.Areas.Layout.Models
{
    public class SigninModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string password { get; set; }

    }
}
