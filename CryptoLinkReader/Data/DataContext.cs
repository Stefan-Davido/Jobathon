using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Entities;

namespace Bookstore.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<NegativeWord> NegativeWord { get; set; }
        public DbSet<PositiveWord> PositiveWord { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NegativeWord>().HasData(
                new Entities.NegativeWord
                    {
                        Id = 1,
                        Word = "Negative"
                    },   new Entities.NegativeWord
                    {
                        Id = 2,
                        Word = "Fall"
                    },   new Entities.NegativeWord
                    {
                        Id = 3,
                        Word = "Destructive"
                    },   new Entities.NegativeWord
                    {
                        Id = 4,
                        Word = "Down"
                    },   new Entities.NegativeWord
                    {
                        Id = 5,
                        Word = "Bad"
                    }
                );

            modelBuilder.Entity<PositiveWord>().HasData(
                new Entities.PositiveWord
                    {
                        Id = 1,
                        Word = "Positive"
                    }, new Entities.PositiveWord
                    {
                        Id = 2,
                        Word = "Up"
                    }, new Entities.PositiveWord
                    {
                        Id = 3,
                        Word = "Great"
                    }, new Entities.PositiveWord
                    {
                        Id = 4,
                        Word = ""
                    }, new Entities.PositiveWord
                    {
                        Id = 5,
                        Word = ""
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
