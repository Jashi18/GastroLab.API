using GastroLab.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastroLab.Data.Data
{
    public class GastroLabDbContext : DbContext
    {
        public GastroLabDbContext(DbContextOptions<GastroLabDbContext> options): base(options){ }


        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
