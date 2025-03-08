using GastroLab.Application.Interfaces;
using GastroLab.Models.RecipeModels;
using Microsoft.AspNetCore.Mvc;

namespace GastroLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var recipes = _recipeService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var recipe = _recipeService.GetRecipeById(id);
                return Ok(recipe);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("bycategory/{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            var recipes = _recipeService.GetRecipesByCategory(categoryId);
            return Ok(recipes);
        }

        [HttpGet("bycountry/{countryId}")]
        public IActionResult GetByCountry(int countryId)
        {
            var recipes = _recipeService.GetRecipesByCountry(countryId);
            return Ok(recipes);
        }

        [HttpGet("byauthor/{authorId}")]
        public IActionResult GetByAuthor(string authorId)
        {
            var recipes = _recipeService.GetRecipesByAuthor(authorId);
            return Ok(recipes);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RecipeCreateModel model)
        {
            try
            {
                var recipeId = _recipeService.CreateRecipe(model);
                return CreatedAtAction(nameof(GetById), new { id = recipeId }, recipeId);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] RecipeUpdateModel model)
        {
            try
            {
                var recipeId = _recipeService.UpdateRecipe(model);
                return Ok(recipeId);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _recipeService.DeleteRecipe(id);
            return Ok(result);
        }
    }
}
