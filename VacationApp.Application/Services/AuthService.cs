using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VacationApp.Common.Entities;
using VacationApp.Common.Models;
using VacationApp.Common.Services;

namespace VacationApp.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfigurationSection _jwtSettings;
    private readonly ILogger<AuthService> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, 
        ILogger<AuthService> logger, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = configuration.GetSection("Jwt");
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<IdentityResult> Register(RegisterModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            throw new Exception("Passwords do not match");
        }
        
        var user = new UserEntity
        {
            Email = model.Email,
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        try
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(user, "Employee");
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message, e);
        }
    }

    public async Task<IdentityResult> CreateAdmin(RegisterModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            throw new Exception("Passwords do not match");
        }
        
        var user = new UserEntity
        {
            Email = model.Email,
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        try
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(user, "Admin");
                await _userManager.AddToRoleAsync(user, "Employee");
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message, e);
        }
    }

    public async Task<IdentityResult> CreateManager(RegisterModel model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            throw new Exception("Passwords do not match");
        }
        
        var user = new UserEntity
        {
            Email = model.Email,
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        try
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                user = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(user, "Manager");
                await _userManager.AddToRoleAsync(user, "Employee");
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message, e);
        }
    }

    public async Task<TokenModel> Login(LoginModel model)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result)
            {
                throw new Exception("Invalid password");
            }
            
            var roles = await _userManager.GetRolesAsync(user);
            
            var token = GenerateToken(user, roles);
            
            return new TokenModel
            {
                Token = token
            };
        }
        catch(Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message, e);
        }
    }

    public async Task Delete(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                throw new Exception("User not found");
            
            var result = await _userManager.DeleteAsync(user);
            
            if (!result.Succeeded)
                throw new Exception("Error while deleting user");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message, e);
        }
    }

    public async Task RefreshPassword(RefreshPasswordModel model)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user is null)
                throw new Exception("User not found");
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, model.Password);
            if (!(await _userManager.CheckPasswordAsync(user, model.Password)))
                throw new Exception("Error while updating password");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task Update(UserUpdateModel model)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if(!await _userManager.IsInRoleAsync(user, "Admin") &&  !await _userManager.IsInRoleAsync(user, "SuperAdmin") 
                                                                        && _httpContextAccessor.HttpContext.
                                                                            User.FindFirstValue(ClaimTypes.NameIdentifier) != user.Id)
                throw new Exception("You are not allowed to update this user");
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            await _userManager.UpdateAsync(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw new Exception(e.Message, e);
        }
    }
    
    public async Task<PagedResult<UserDto>> GetPaged(int page,int pageSize)
    {
        var managerRole = await _roleManager.FindByNameAsync("Manager");
        var employeeRole = await _roleManager.FindByNameAsync("Employee");
        var users = (await _userManager.GetUsersInRoleAsync(employeeRole.Name)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return new PagedResult<UserDto>
        {
            Items = users.Select(x => new UserDto(x)).ToList(),
            Page = page,
            PageSize = pageSize,
            TotalCount = _userManager.GetUsersInRoleAsync(employeeRole.Name).Result.Count
        };
    }

    public async Task<TokenModel> RefreshToken()
    {
        var user = await _userManager.FindByIdAsync(
            _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        if (user is null)
            throw new Exception("User Not Found");
        
        var roles = await _userManager.GetRolesAsync(user);
        
        var token = GenerateToken(user, roles);
        
        return new TokenModel
        {
            Token = token
        };
    }

    private string GenerateToken(UserEntity user, IList<string> roles)
    {
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
        };
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetSecretKey()));

        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

        var tokenOptions = new JwtSecurityToken(
            issuer: GetIssuer(),
            audience: GetAudience(),
            claims: claims,
            expires: DateTime.Now.AddHours(48),
            signingCredentials: signInCredentials);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        
        return token;
    }
    
    
    private string GetSecretKey() => _jwtSettings["JwtSecretKey"];

    private string GetIssuer() => _jwtSettings["Issuer"];

    private string GetAudience() => _jwtSettings["Audience"];
}