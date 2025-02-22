namespace GastroLab.Data.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FlagUrl { get; set; } = string.Empty;

        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
