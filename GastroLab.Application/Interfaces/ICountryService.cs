using GastroLab.Data.Entities;
using GastroLab.Models.CategoryModels;
using GastroLab.Models.CountryModels;

namespace GastroLab.Application.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<CountryListModel> GetAllCountries();
        CountryListModel GetCountryById(int id);
        int CreateCountry(CountryCreateModel countryModel);
        int UpdateCountry(CountryUpdateModel countryModel);
        bool DeleteCountry(int id);
    }
}
