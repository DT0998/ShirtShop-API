using API.Models.Shirt.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var strShirtId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strShirtId, out int Id))
            {
                if (!ShirtRepository.ShirtExists(Id))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesnt exists anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound

                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
