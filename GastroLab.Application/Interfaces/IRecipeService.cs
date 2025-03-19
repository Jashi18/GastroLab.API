using GastroLab.Models.RecipeModels;

namespace GastroLab.Application.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipeListModel> GetAllRecipes();
        IEnumerable<RecipeListModel> GetRecipesByCategory(int categoryId);
        IEnumerable<RecipeListModel> GetRecipesByCountry(int countryId);
        IEnumerable<RecipeListModel> GetRecipesByAuthor(string authorId);
        RecipeDetailModel GetRecipeById(int id);
        int CreateRecipe(RecipeCreateModel recipeModel, string userId);
        int UpdateRecipe(RecipeUpdateModel recipeModel, string userId);
        bool DeleteRecipe(int id, string userId);
        Task<IEnumerable<RecipeListModel>> GetMostRatedRecipesAsync(int count = 10);
        Task<IEnumerable<RecipeListModel>> GetHighestRatedRecipesAsync(int count = 10, double minRating = 4.0);
    }
}
