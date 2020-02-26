using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mec.WebUI.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }
        [Required(ErrorMessage ="Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen bir şehir giriniz.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen bir ilçe giriniz.")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "Lütfen bir mahalle giriniz.")]
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
    }
}