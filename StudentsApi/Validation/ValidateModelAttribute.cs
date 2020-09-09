using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentsApi.Errors;

namespace StudentsApi.Validation
{
    internal class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
                actionContext.Result = new BadRequestObjectResult(
                    new
                    {
                        Errors = actionContext.ModelState.Keys
                            .SelectMany(key => actionContext.ModelState[key].Errors.Select(x => new
                            {
                                Code = (int)ErrorType.InvalidInputData,
                                Message = $"{key}: {x.ErrorMessage}"
                            })).ToList()
                    });
        }
    }
}
