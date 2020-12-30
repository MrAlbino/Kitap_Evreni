using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web_Prog_Proje.Models;

namespace Web_Prog_Proje.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kitap> Kitap { get; set; }
        public DbSet<Dil> Dil { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<KitapYazar> KitapYazar { get; set; }
        public DbSet<KitapKarakter> KitapKarakter { get; set; }
        public DbSet<Yazar> Yazar { get; set; }
        public DbSet<Karakter> Karakter { get; set; }
        public DbSet<Ulke> Ulke { get; set; }

    }
}
