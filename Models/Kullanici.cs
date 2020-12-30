using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class Kullanici:IdentityUser
    {
        [Display(Name ="Ad")]
        public string Ad { get; set; }
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }
    }
}
