using GastroLab.Application.Interfaces;
using GastroLab.Models.RatingModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GastroLab.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        [HttpPost]
        public async Task<ActionResult<RatingViewModel>> AddOrUpdateRating(RatingCreateModel model)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _ratingService.AddOrUpdateRatingAsync(model, userId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{recipeId}")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> GetRatingInfo(int recipeId)
        {
            try
            {
                var averageRating = await _ratingService.GetAverageRatingAsync(recipeId);
                var ratingCount = await _ratingService.GetRatingCountAsync(recipeId);

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userRating = userId != null
                    ? await _ratingService.GetUserRatingAsync(recipeId, userId)
                    : null;

                return Ok(new
                {
                    averageRating,
                    ratingCount,
                    userRating
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult> DeleteRating(int recipeId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _ratingService.DeleteRatingAsync(recipeId, userId);

                if (!result)
                    return NotFound("Rating not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
