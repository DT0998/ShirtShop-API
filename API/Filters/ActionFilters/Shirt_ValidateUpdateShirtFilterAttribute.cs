﻿using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters.ActionFilters
{
    public class Shirt_ValidateUpdateShirtFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as ShirtDto;

            if (id.HasValue && shirt != null && id != shirt.Id)
            {
                context.ModelState.AddModelError("Id", "ShirtId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest

                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
