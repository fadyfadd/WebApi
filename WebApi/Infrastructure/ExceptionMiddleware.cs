using System.Text.Json;
using WebApi;

namespace Infrastructure.WebApi;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionMiddleware> logger;
    private readonly IHostEnvironment env;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        this.env = env;
        this.logger = logger;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            ApiException response = null;
            context.Response.ContentType = "application/json";

            if (env.IsDevelopment())
            {

                if (ex is ApplicationError)
                {
                    response = new ApiException(context.Response.StatusCode, ex.Message , "");
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                }

                else {
                    response = new ApiException(context.Response.StatusCode, ex.Message , ex.ToString());
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                }
                   
            }
            else
            {
                if (ex is ApplicationError) {
                    response = new ApiException(context.Response.StatusCode, ex.Message , "");
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                }

                else {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                    response = new ApiException(context.Response.StatusCode, "Internal Server Error" , "");
                }
                  
            }
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }
    }
}
