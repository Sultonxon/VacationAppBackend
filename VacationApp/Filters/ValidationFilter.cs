using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VacationApp.Filters;

public class ValidationFilter :  Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(context.ModelState.IsValid)
        {
            await next();
        }
        else
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}