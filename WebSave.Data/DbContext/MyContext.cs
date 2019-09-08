using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebSave.Model;
using Microsoft.AspNetCore.Identity;

namespace WebSave.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
                : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileType>().HasOne(x => x.User).WithMany(x => x.FileTypes).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<File>().HasOne(x => x.FileType).WithMany(x => x.Files).HasForeignKey(x => x.FileTypeId);
        }

        public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
