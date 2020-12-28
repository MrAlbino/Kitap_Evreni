using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public int? UlkeId { get; set; }
        public Ulke Ulke { get; set; }
        public string AdSoyad { get { return Ad + " " + Soyad; } }

    }
}
