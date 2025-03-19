namespace GastroLab.Data.Entities
{
    public class Rating : BaseEntity
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int Value { get; set; }

        public Recipe? Recipe { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
