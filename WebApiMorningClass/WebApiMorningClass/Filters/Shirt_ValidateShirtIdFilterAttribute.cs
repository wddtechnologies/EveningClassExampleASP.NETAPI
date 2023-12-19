using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiMorningClass.Models.Repositories;

namespace WebApiMorningClass.Filters
{
    public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue) 
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtID", "ShirtID is invalid.");
                    // var problemDetails = new ValidationProblemsDetails(context.ModelState)
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                else if(!ShirtRepository.ShirtExists(shirtId.Value)) 
                {
                    context.ModelState.AddModelError("ShirtID", "ShirtID does not exist!.");
                    context.Result = new NotFoundObjectResult(context.ModelState);

                    //context.Result = new NotFoundObjectResult(context.problemDetails);

                }
            }
        }
    }
}
