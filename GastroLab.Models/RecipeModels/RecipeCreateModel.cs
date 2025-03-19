using GastroLab.Models.NutritionalInfoModels;

namespace GastroLab.Models.RecipeModels
{
    public class RecipeCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CookingTime { get; set; }
        public int CountryId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public List<IngredientCreateModel> Ingredients { get; set; } = new List<IngredientCreateModel>();
        public List<int> CategoryIds { get; set; } = new List<int>();
        public NutritionalInfoModel? NutritionalInfo { get; set; }
        public List<int> DietaryTagIds { get; set; } = new List<int>();
    }

    public class IngredientCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
    }
}
