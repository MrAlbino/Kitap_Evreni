using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class KitapYorum
    {
        public Kitap kitap { get; set; }
        public IEnumerable<Yorumlar> yorum { get; set; }
    }
}
