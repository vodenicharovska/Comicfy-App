using Comicfy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Data
{
    public class AppDbContext :IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MCharacter_ComicBook>().HasKey(mccb => new
            {
                mccb.CharacterId,
                mccb.ComicBookId
            });

            modelBuilder.Entity<MCharacter_ComicBook>().HasOne(cb => cb.ComicBook).WithMany(mccb => mccb.Characters_ComicBooks).HasForeignKey(cb => cb.ComicBookId);

            modelBuilder.Entity<MCharacter_ComicBook>().HasOne(cb => cb.MainCharacter).WithMany(mccb => mccb.Characters_ComicBooks).HasForeignKey(cb => cb.CharacterId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MainCharacter> MainCharacters { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<CoverArtist> CoverArtists { get; set; }
        public DbSet<Penciler> Pencilers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<MCharacter_ComicBook> Characters_ComicBooks { get; set; }

        //Order related tables

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
