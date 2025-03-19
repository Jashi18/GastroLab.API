namespace GastroLab.Data.Entities
{
    public class Recipe : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CookingTime { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public NutritionalInfo? NutritionalInfo { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<DietaryTag> DietaryTags { get; set; } = new List<DietaryTag>();
        public string ImageUrl { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
    }
}
