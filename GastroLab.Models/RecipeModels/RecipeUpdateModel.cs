namespace GastroLab.Models.RecipeModels
{
    public class RecipeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CookingTime { get; set; }
        public int CountryId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<IngredientUpdateModel> Ingredients { get; set; } = new List<IngredientUpdateModel>();
        public List<int> CategoryIds { get; set; } = new List<int>();
    }

    public class IngredientUpdateModel
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
