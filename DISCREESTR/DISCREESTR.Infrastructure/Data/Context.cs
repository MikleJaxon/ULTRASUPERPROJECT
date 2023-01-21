using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DISCREESTR.DOMAIN;
using Microsoft.EntityFrameworkCore;

namespace DISCREESTR.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Studplan> Studplans { get; set; }
        public DbSet<Prep> Preps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Studplan>().HasKey(u => u.Id);
           // modelBuilder.Entity<Prep>().HasKey(u => u.Id);
        }
    }
}