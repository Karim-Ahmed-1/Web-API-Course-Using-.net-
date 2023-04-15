using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;
using WebApplication2.Models;

namespace WebApplication2.Filters
{
    public class ValidateTypeFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var car = context.ActionArguments["car"] as Car;

            var regex = new Regex("^(Electric|Gas|Diesel|Hybrid)$", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
            
            if(car.type == null || !regex.IsMatch(car.type) ) 
            {
                context.ModelState.AddModelError("type", "type Isnot Valid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}


//using DotNet_API.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Text.RegularExpressions;

//namespace DotNet_API.CustomFilters
//{
//    public class TypeFilterAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            var car = context.ActionArguments["car"] as Car;
//            var regex = new Regex("^(Eletric|Gas|Diesel|Hybrid)$", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));

//            if (car.Type == null || !regex.IsMatch(car.Type))
//            {
//                context.ModelState.AddModelError("Type", "Car Is Not Valid");
//                context.Result = new BadRequestObjectResult(context.ModelState);
//            }
//        }
//    }
//}