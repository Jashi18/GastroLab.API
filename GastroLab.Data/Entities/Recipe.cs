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

        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public string ImageUrl { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
    }
}
