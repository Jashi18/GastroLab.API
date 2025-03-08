namespace GastroLab.Models.CountryModels
{
    public class CountryUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FlagUrl { get; set; } = string.Empty;
    }
}
