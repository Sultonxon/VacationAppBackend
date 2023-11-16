using Microsoft.AspNetCore.Identity;
using VacationApp.Common.Entities;
using VacationApp.Common.Models;

namespace VacationApp.Common.Services;

public interface IAuthService
{
    Task<IdentityResult> Register(RegisterModel model);
    Task<IdentityResult> CreateAdmin(RegisterModel model);
    Task<IdentityResult> CreateManager(RegisterModel model);
    Task<TokenModel> Login(LoginModel model);
    Task<TokenModel> RefreshToken();
    Task Delete(string id);

    Task RefreshPassword(RefreshPasswordModel model);

    Task Update(UserUpdateModel model);
    
    Task<PagedResult<UserDto>> GetPaged(int page,int pageSize);
}