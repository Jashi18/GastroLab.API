using GastroLab.Application.Interfaces;
using GastroLab.Data.Data;
using GastroLab.Data.Entities;
using GastroLab.Models.RatingModels;
using Microsoft.EntityFrameworkCore;

namespace GastroLab.Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly GastroLabDbContext _dbContext;

        public RatingService(GastroLabDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RatingViewModel> AddOrUpdateRatingAsync(RatingCreateModel model, string userId)
        {
            var recipe = await _dbContext.Recipes
                .FirstOrDefaultAsync(r => r.Id == model.RecipeId && r.DeleteDate == null);

            if (recipe == null)
                throw new KeyNotFoundException($"Recipe with ID {model.RecipeId} not found");

            var rating = await _dbContext.Ratings
                .FirstOrDefaultAsync(r => r.RecipeId == model.RecipeId && r.UserId == userId);

            if (rating == null)
            {
                rating = new Rating
                {
                    RecipeId = model.RecipeId,
                    UserId = userId,
                    Value = model.Value,
                    CreateDate = DateTime.UtcNow
                };

                _dbContext.Ratings.Add(rating);
            }
            else
            {
                rating.Value = model.Value;
                rating.UpdateDate = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();

            var user = await _dbContext.Users.FindAsync(userId);

            return new RatingViewModel
            {
                Id = rating.Id,
                RecipeId = rating.RecipeId,
                UserId = rating.UserId,
                UserName = user?.UserName ?? string.Empty,
                Value = rating.Value,
                CreateDate = rating.CreateDate
            };
        }
        public async Task<RatingViewModel?> GetUserRatingAsync(int recipeId, string userId)
        {
            var rating = await _dbContext.Ratings
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.UserId == userId);

            if (rating == null)
                return null;

            return new RatingViewModel
            {
                Id = rating.Id,
                RecipeId = rating.RecipeId,
                UserId = rating.UserId,
                UserName = rating.User?.UserName ?? string.Empty,
                Value = rating.Value,
                CreateDate = rating.CreateDate
            };
        }
        public async Task<double> GetAverageRatingAsync(int recipeId)
        {
            var ratings = await _dbContext.Ratings
                .Where(r => r.RecipeId == recipeId)
                .ToListAsync();

            if (!ratings.Any())
                return 0;

            return Math.Round(ratings.Average(r => r.Value), 1);
        }
        public async Task<int> GetRatingCountAsync(int recipeId)
        {
            return await _dbContext.Ratings
                .CountAsync(r => r.RecipeId == recipeId);
        }
        public async Task<bool> DeleteRatingAsync(int recipeId, string userId)
        {
            var rating = await _dbContext.Ratings
                .FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.UserId == userId);

            if (rating == null)
                return false;

            _dbContext.Ratings.Remove(rating);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
