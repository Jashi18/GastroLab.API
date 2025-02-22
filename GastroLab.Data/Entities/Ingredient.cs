namespace GastroLab.Data.Entities
{
    public class Ingredient : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;

        public int RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}
