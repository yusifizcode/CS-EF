using CSharp_EF_Stadium.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_EF_Stadium.Data.DAL
{
    internal class StadiumDbContext:DbContext
    {
        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1TG370G;Database=StadiumEF;Trusted_Connection=TRUE");
        }
    }
}
