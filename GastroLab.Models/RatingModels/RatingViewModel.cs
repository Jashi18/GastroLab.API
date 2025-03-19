namespace GastroLab.Models.RatingModels
{
    public class RatingViewModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int Value { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
