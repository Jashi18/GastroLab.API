using GastroLab.Models.AuthModels;

namespace GastroLab.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegistrationModel model);
        Task<AuthResponse> LoginAsync(LoginModel model);
    }
}
