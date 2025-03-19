namespace GastroLab.Models.NutritionalInfoModels
{
    public class NutritionalInfoModel
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public string ServingSize { get; set; } = string.Empty;
    }
}
