using GastroLab.Application.Interfaces;
using GastroLab.Data.Data;
using GastroLab.Data.Entities;
using GastroLab.Models.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace GastroLab.Application.Services
{
    public class RecipeService(GastroLabDbContext dbContext) : IRecipeService
    {
        private readonly GastroLabDbContext _dbContext = dbContext;

        public IEnumerable<RecipeListModel> GetAllRecipes()
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.DeleteDate == null)
                .Include(r => r.Country)
                .Include(r => r.Categories)
                .Select(r => new RecipeListModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CookingTime = r.CookingTime,
                    CountryId = r.CountryId,
                    CountryName = r.Country != null ? r.Country.Name : string.Empty,
                    ImageUrl = r.ImageUrl,
                    AuthorId = r.AuthorId,
                    Categories = r.Categories.Where(c => c.DeleteDate == null).Select(c => c.Name).ToList()
                })
                .ToList();

            return recipes;
        }
        public IEnumerable<RecipeListModel> GetRecipesByCategory(int categoryId)
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.DeleteDate == null && r.Categories.Any(c => c.Id == categoryId && c.DeleteDate == null))
                .Include(r => r.Country)
                .Include(r => r.Categories)
                .Select(r => new RecipeListModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CookingTime = r.CookingTime,
                    CountryId = r.CountryId,
                    CountryName = r.Country != null ? r.Country.Name : string.Empty,
                    ImageUrl = r.ImageUrl,
                    AuthorId = r.AuthorId,
                    Categories = r.Categories.Where(c => c.DeleteDate == null).Select(c => c.Name).ToList()
                })
                .ToList();

            return recipes;
        }
        public IEnumerable<RecipeListModel> GetRecipesByCountry(int countryId)
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.DeleteDate == null && r.CountryId == countryId)
                .Include(r => r.Country)
                .Include(r => r.Categories)
                .Select(r => new RecipeListModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CookingTime = r.CookingTime,
                    CountryId = r.CountryId,
                    CountryName = r.Country != null ? r.Country.Name : string.Empty,
                    ImageUrl = r.ImageUrl,
                    AuthorId = r.AuthorId,
                    Categories = r.Categories.Where(c => c.DeleteDate == null).Select(c => c.Name).ToList()
                })
                .ToList();

            return recipes;
        }
        public IEnumerable<RecipeListModel> GetRecipesByAuthor(string authorId)
        {
            var recipes = _dbContext.Recipes
                .Where(r => r.DeleteDate == null && r.AuthorId == authorId)
                .Include(r => r.Country)
                .Include(r => r.Categories)
                .Select(r => new RecipeListModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CookingTime = r.CookingTime,
                    CountryId = r.CountryId,
                    CountryName = r.Country != null ? r.Country.Name : string.Empty,
                    ImageUrl = r.ImageUrl,
                    AuthorId = r.AuthorId,
                    Categories = r.Categories.Where(c => c.DeleteDate == null).Select(c => c.Name).ToList()
                })
                .ToList();

            return recipes;
        }
        public RecipeDetailModel GetRecipeById(int id)
        {
            var recipe = _dbContext.Recipes
                .Where(r => r.DeleteDate == null && r.Id == id)
                .Include(r => r.Country)
                .Include(r => r.Ingredients.Where(i => i.DeleteDate == null))
                .Include(r => r.Categories.Where(c => c.DeleteDate == null))
                .Select(r => new RecipeDetailModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CookingTime = r.CookingTime,
                    CountryId = r.CountryId,
                    CountryName = r.Country != null ? r.Country.Name : string.Empty,
                    ImageUrl = r.ImageUrl,
                    AuthorId = r.AuthorId,
                    Ingredients = r.Ingredients
                        .Where(i => i.DeleteDate == null)
                        .Select(i => new IngredientModel
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Amount = i.Amount
                        }).ToList(),
                    Categories = r.Categories
                        .Where(c => c.DeleteDate == null)
                        .Select(c => new CategoryModel
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList()
                })
                .FirstOrDefault();

            return recipe ?? throw new KeyNotFoundException($"Recipe with ID {id} not found");
        }
        public int CreateRecipe(RecipeCreateModel recipeModel, string userId)
        {
            var country = _dbContext.Countries
                .FirstOrDefault(c => c.DeleteDate == null && c.Id == recipeModel.CountryId);

            if (country == null)
                throw new KeyNotFoundException($"Country with ID {recipeModel.CountryId} not found");

            var categories = _dbContext.Categories
                .Where(c => c.DeleteDate == null && recipeModel.CategoryIds.Contains(c.Id))
                .ToList();

            if (categories.Count != recipeModel.CategoryIds.Count)
                throw new KeyNotFoundException("One or more categories not found");

            var recipe = new Recipe
            {
                Name = recipeModel.Name,
                Description = recipeModel.Description,
                CookingTime = recipeModel.CookingTime,
                CountryId = recipeModel.CountryId,
                ImageUrl = recipeModel.ImageUrl,
                AuthorId = userId,
                CreateDate = DateTime.UtcNow
            };

            foreach (var ingredientModel in recipeModel.Ingredients)
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    Name = ingredientModel.Name,
                    Amount = ingredientModel.Amount,
                    CreateDate = DateTime.UtcNow
                });
            }

            foreach (var category in categories)
            {
                recipe.Categories.Add(category);
            }

            _dbContext.Recipes.Add(recipe);
            _dbContext.SaveChanges();

            return recipe.Id;
        }
        public int UpdateRecipe(RecipeUpdateModel recipeModel, string userId)
        {
            var recipe = _dbContext.Recipes
                .Include(r => r.Ingredients.Where(i => i.DeleteDate == null))
                .Include(r => r.Categories)
                .FirstOrDefault(r => r.DeleteDate == null && r.Id == recipeModel.Id);

            if (recipe == null)
                throw new KeyNotFoundException($"Recipe with ID {recipeModel.Id} not found");

            if (recipe.AuthorId != userId)
                throw new KeyNotFoundException($"Recipe with ID {recipeModel.Id} not found");

            var country = _dbContext.Countries
                .FirstOrDefault(c => c.DeleteDate == null && c.Id == recipeModel.CountryId);

            if (country == null)
                throw new KeyNotFoundException($"Country with ID {recipeModel.CountryId} not found");

            var categories = _dbContext.Categories
                .Where(c => c.DeleteDate == null && recipeModel.CategoryIds.Contains(c.Id))
                .ToList();

            if (categories.Count != recipeModel.CategoryIds.Count)
                throw new KeyNotFoundException("One or more categories not found");

            recipe.Name = recipeModel.Name;
            recipe.Description = recipeModel.Description;
            recipe.CookingTime = recipeModel.CookingTime;
            recipe.CountryId = recipeModel.CountryId;
            recipe.ImageUrl = recipeModel.ImageUrl;
            recipe.UpdateDate = DateTime.UtcNow;

            var existingIngredientIds = recipe.Ingredients
                .Where(i => i.DeleteDate == null)
                .Select(i => i.Id)
                .ToList();

            var updatedIngredientIds = recipeModel.Ingredients
                .Where(i => i.Id.HasValue && !i.IsDeleted)
                .Select(i => i.Id.Value)
                .ToList();

            var ingredientsToDelete = recipe.Ingredients
                .Where(i => i.DeleteDate == null && !updatedIngredientIds.Contains(i.Id))
                .ToList();

            foreach (var ingredient in ingredientsToDelete)
            {
                ingredient.DeleteDate = DateTime.UtcNow;
            }

            foreach (var ingredientModel in recipeModel.Ingredients.Where(i => i.Id.HasValue && !i.IsDeleted))
            {
                var ingredient = recipe.Ingredients.FirstOrDefault(i => i.Id == ingredientModel.Id.Value);
                if (ingredient != null)
                {
                    ingredient.Name = ingredientModel.Name;
                    ingredient.Amount = ingredientModel.Amount;
                    ingredient.UpdateDate = DateTime.UtcNow;
                }
            }

            foreach (var ingredientModel in recipeModel.Ingredients.Where(i => !i.Id.HasValue && !i.IsDeleted))
            {
                recipe.Ingredients.Add(new Ingredient
                {
                    Name = ingredientModel.Name,
                    Amount = ingredientModel.Amount,
                    CreateDate = DateTime.UtcNow
                });
            }
            recipe.Categories.Clear();

            foreach (var category in categories)
            {
                recipe.Categories.Add(category);
            }

            _dbContext.SaveChanges();

            return recipe.Id;
        }
        public bool DeleteRecipe(int id, string userId)
        {
            var recipe = _dbContext.Recipes
                .FirstOrDefault(r => r.DeleteDate == null && r.Id == id);

            if (recipe == null)
                return false;

            if (recipe.AuthorId != userId)
                throw new UnauthorizedAccessException("You are not authorized to delete this recipe");

            recipe.DeleteDate = DateTime.UtcNow;
            _dbContext.SaveChanges();

            return true;
        }
    }
}
