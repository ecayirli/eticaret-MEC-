using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mec.WebUI.Models
{
    public class Register
    {
        [DisplayName("Adınız")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Soyadınız")]
        [Required]
        public string Surname { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required]
        public string Username { get; set; }
        [DisplayName("E-posta")]
        [Required]
        [EmailAddress(ErrorMessage ="E-posta adresinizi uygun şekilde tekrar giriniz.")]
        public string Email { get; set; }
        [DisplayName("Şifreniz")]
        [Required]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar")]
        [Required]
        [Compare("Password",ErrorMessage ="Girdiğiniz şifre uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}