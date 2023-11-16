using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacationApp.Common.Models;
using VacationApp.Common.Services;
using VacationApp.Filters;

namespace VacationApp.Controllers;

[Route("api/[controller]")]
public class VacationController : Controller
{
    private readonly IVacationService _vacationService;
    
    public VacationController(IVacationService vacationService)
    {
        _vacationService = vacationService;
    }
    
    [HttpPost("create")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> Create([FromBody]VacationCreateModel model)
    {
        try
        {
            await _vacationService.Create(model.DateFrom, model.DateTo, model.Reason);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    [HttpPost("approve/{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ValidationFilter]
    public async Task<IActionResult> Approve(string id)
    {
        try
        {
            await _vacationService.Approve(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("reject")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    [ValidationFilter]
    public async Task<IActionResult> Reject([FromBody]VacationRejectModel model)
    {
        try
        {
            await _vacationService.Reject(model.Id, model.Comment);
            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("delete/{id}")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _vacationService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("available")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> AvailableDaysForThisYear()
    {
        try
        {
            var days = await _vacationService.AvailableDaysForThisYear();
            return Ok(new
            {
                AvailableDays= days
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("all")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> GetAll([FromQuery]int page, [FromQuery]int pageSize)
    {
        try
        {
            var vacations = await _vacationService.GetPaged(page, pageSize);
            return Ok(vacations);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("user")]
    [Authorize]
    [ValidationFilter]
    public async Task<IActionResult> GetByUser([FromQuery]int page, [FromQuery]int pageSize)
    {
        try
        {
            var vacations = await _vacationService.GetByUserId(page, pageSize);
            return Ok(vacations);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("users/{userId}/{page}/{pageSize}")]
    public async Task<IActionResult> GetByUserId(string userId, int page, int pageSize)
    {
        return Ok(await _vacationService.GetByUserId(pageSize:pageSize, page:page, userId:userId));
    }
}