using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class JwtContext : DbContext
    {
        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<AppRole>? AppRoles { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public JwtContext(DbContextOptions<JwtContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }

    }
}
