using WebApplication2.Models;

namespace WebApplication2.Middlewares
{
    public class RequestCounterMiddleware : IMiddleware
    {
        public async  Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var request = context.RequestServices.GetService<Request>();
            if(request != null) { request.Count += 1; }
            await next.Invoke(context);
        }
    }
}
