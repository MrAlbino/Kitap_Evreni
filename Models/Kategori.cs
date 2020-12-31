using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        [Required]
        public string KategoriAd { get; set; }
        //public ICollection<Kitap> Kitap { get; set; }
    }
}
