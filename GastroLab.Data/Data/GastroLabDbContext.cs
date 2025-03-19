using GastroLab.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GastroLab.Data.Data
{
    public class GastroLabDbContext : IdentityDbContext<ApplicationUser>
    {
        public GastroLabDbContext(DbContextOptions<GastroLabDbContext> options): base(options){ }


        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
