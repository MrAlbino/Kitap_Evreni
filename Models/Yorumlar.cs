using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class Yorumlar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string  Yorum { get; set; }
        public int KitapId { get; set; }
        public virtual Kitap Kitap { get; set; }

    }
}
