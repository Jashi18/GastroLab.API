using GastroLab.Application.Interfaces;
using GastroLab.Data.Data;
using GastroLab.Data.Entities;
using GastroLab.Models.CountryModels;

namespace GastroLab.Application.Services
{
    public class CountryService(GastroLabDbContext dbContext) : ICountryService
    {
        private readonly GastroLabDbContext _dbContext = dbContext;

        public IEnumerable<CountryListModel> GetAllCountries()
        {
            var countries = _dbContext.Countries
                .Where(x => x.DeleteDate == null)
                .Select(x => new CountryListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FlagUrl = x.FlagUrl,
                });
            return countries;
        }
        public CountryListModel GetCountryById(int id)
        {
            var country = _dbContext.Countries
                .Where(x => x.DeleteDate == null && x.Id == id)
                .Select(x => new CountryListModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FlagUrl = x.FlagUrl,
                }).FirstOrDefault();
            return country ?? throw new ArgumentNullException();
        }
        public int CreateCountry(CountryCreateModel countryModel)
        {
            var country = new Country
            {
                Name = countryModel.Name,
                FlagUrl = countryModel.FlagUrl,
                CreateDate = DateTime.UtcNow,
            };
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return country.Id;
        }
        public int UpdateCountry(CountryUpdateModel countryModel)
        {
            var country = _dbContext.Countries
                .FirstOrDefault(x => x.DeleteDate == null && x.Id == countryModel.Id);

            if (country == null)
                throw new KeyNotFoundException($"Category with ID {countryModel.Id} not found");

            country.Name = countryModel.Name;
            country.FlagUrl = countryModel.FlagUrl;
            country.UpdateDate = DateTime.UtcNow;

            _dbContext.SaveChanges();

            return country.Id;
        }
        public bool DeleteCountry(int id)
        {
            var country = _dbContext.Countries
                .FirstOrDefault(x => x.DeleteDate == null && x.Id == id);

            if (country == null)
                return false;

            country.DeleteDate = DateTime.UtcNow;
            _dbContext.SaveChanges();

            return true;
        }
    }
}
