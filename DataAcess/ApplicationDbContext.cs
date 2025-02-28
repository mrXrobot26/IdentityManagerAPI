﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Domain;

namespace DataAcess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Image> Image { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Dictionary<string, string> roles = new Dictionary<string, string>
            {
                { "43d0590f-2f82-4867-83c4-18f0488f9706", "admin" },
                { "ff715d53-7725-48de-8d74-f064b8b41b45", "user" },
                { "5654533a-52b5-4e1e-b9e5-fd8036ef35ff", "manager" },
                { "2b440d41-47fa-4fe5-ae96-b4ae34d223a1", "guest" }
            };
            foreach (var role in roles)
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Id = role.Key,
                    Name = role.Value,
                    NormalizedName = role.Value.ToUpper()
                });
            }
        }

    }
}
