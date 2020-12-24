using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class KitapKarakter
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }
        public int KarakterId { get; set; }
        public Karakter Karakter { get; set; }
        public int? Sira { get; set; }

    }
}
