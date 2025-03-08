using GastroLab.Application.Interfaces;
using GastroLab.Models.CountryModels;
using Microsoft.AspNetCore.Mvc;

namespace GastroLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var countries = _countryService.GetAllCountries();
            return Ok(countries);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var country = _countryService.GetCountryById(id);
                return Ok(country);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] CountryCreateModel model)
        {
            var countryId = _countryService.CreateCountry(model);
            return CreatedAtAction(nameof(GetById), new { id = countryId }, countryId);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CountryUpdateModel model)
        {
            try
            {
                var countryId = _countryService.UpdateCountry(model);
                return Ok(countryId);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _countryService.DeleteCountry(id);
            return Ok(result);
        }
    }
}
