using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VacationApp.Common.Models;
using VacationApp.Common.Services;
using VacationApp.Filters;

namespace VacationApp.Controllers;

[Authorize]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ValidationFilter]
    public async Task<IActionResult> Register([FromBody]RegisterModel model)
    {
        var result = await _authService.Register(model);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpPost("register-admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    [ValidationFilter]
    public async Task<IActionResult> CreateAdmin([FromBody]RegisterModel model)
    {
        var result = await _authService.CreateAdmin(model);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }
    
    [HttpPost("register-manager")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    [ValidationFilter]
    public async Task<IActionResult> CreateManager([FromBody]RegisterModel model)
    {
        var result = await _authService.CreateManager(model);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    [ValidationFilter]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {
        try
        {
            
            var token = await _authService.Login(model);
            if (token is null)
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(token);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
    
    [HttpPost("update")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> Update([FromBody]UserUpdateModel model)
    {
        try
        {
            await _authService.Update(model);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("refresh-token")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> RefreshToken()
    {
        try
        {
            return Ok(await _authService.RefreshToken());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("employees/{page}/{pageSize}")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> GetEmployees(int page, int pageSize)
    {
        return Ok(await _authService.GetPaged(page, pageSize));
    }
    
    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ValidationFilter]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _authService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("refresh-password")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ValidationFilter]
    public async Task<IActionResult> RefreshPassword([FromBody]RefreshPasswordModel model)
    {
        try
        {
            await _authService.RefreshPassword(model);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}