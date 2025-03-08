namespace GastroLab.Models.RecipeModels
{
    public class RecipeDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CookingTime { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
