using GastroLab.Models.RatingModels;

namespace GastroLab.Application.Interfaces
{
    public interface IRatingService
    {
        Task<RatingViewModel> AddOrUpdateRatingAsync(RatingCreateModel model, string userId);
        Task<RatingViewModel?> GetUserRatingAsync(int recipeId, string userId);
        Task<double> GetAverageRatingAsync(int recipeId);
        Task<int> GetRatingCountAsync(int recipeId);
        Task<bool> DeleteRatingAsync(int recipeId, string userId);
    }
}
