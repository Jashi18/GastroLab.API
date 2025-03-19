using GastroLab.Models.NutritionalInfoModels;

namespace GastroLab.Models.RecipeModels
{
    public class RecipeListModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CookingTime { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new List<string>();
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
        public NutritionalInfoModel? NutritionalInfo { get; set; }
    }
}
