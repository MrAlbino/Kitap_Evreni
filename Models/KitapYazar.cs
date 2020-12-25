﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Prog_Proje.Models
{
    public class KitapYazar
    {
        public int Id { get; set; }
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        public string YazarTip { get; set; }
    }
}
