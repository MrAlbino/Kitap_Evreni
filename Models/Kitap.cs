using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class Kitap
    {
        public int Id { get; set; }

        [Required]
        public string KitapAd { get; set; }
        public int SayfaSayisi { get; set; }
        public int? BasimYili { get; set; }
        [Required]
        public string Konu { get; set; }
        [Required]
        public string Resim { get; set; }
        [Required]
        public string ArkaplanResim { get; set; }

        public int? KategoriId { get; set; }
        public Kategori Kategori { get; set; }      
        public int? DilId { get; set; }
        public Dil Dil { get; set; }
        public ICollection<Yorumlar> Yorumlar { get; set; }

    }
}
