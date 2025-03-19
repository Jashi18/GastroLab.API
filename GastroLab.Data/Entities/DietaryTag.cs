namespace GastroLab.Data.Entities
{
    public class DietaryTag : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
