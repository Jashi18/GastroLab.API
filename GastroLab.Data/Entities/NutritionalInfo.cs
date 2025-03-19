using System.ComponentModel.DataAnnotations.Schema;

namespace GastroLab.Data.Entities
{
    public class NutritionalInfo : BaseEntity
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public string ServingSize { get; set; } = string.Empty;

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
