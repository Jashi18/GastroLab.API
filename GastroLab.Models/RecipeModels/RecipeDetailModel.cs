﻿using GastroLab.Models.DietaryTagModels;
using GastroLab.Models.NutritionalInfoModels;

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
        public double AverageRating { get; set; }
        public int RatingsCount { get; set; }
        public List<IngredientModel> Ingredients { get; set; } = new List<IngredientModel>();
        public List<DietaryTagCreateModel> DietaryTags { get; set; } = new List<DietaryTagCreateModel>();
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        public NutritionalInfoModel? NutritionalInfo { get; set; }
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
