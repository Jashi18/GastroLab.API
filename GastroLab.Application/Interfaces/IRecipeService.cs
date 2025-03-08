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
        int CreateRecipe(RecipeCreateModel recipeModel);
        int UpdateRecipe(RecipeUpdateModel recipeModel);
        bool DeleteRecipe(int id);
    }
}
