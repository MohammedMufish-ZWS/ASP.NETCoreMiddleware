var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//if u execute above code it will map / route & will give Hello Worl
//app.MapDefaultControllerRoute();
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("app.{Map,use,run,Next} done");
    await next(context);
});
//Use can take two parameters as arguments
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("\n\tMiddleware done");
    await next(context);
});
app.Run(async (context) =>
{
    await context.Response.WriteAsync("\n\t\t Vikram is Part Of LCU.");
});
//Run can take only one parameter as argument
//after executing Run you can't excute subsequent Middleware

app.Run();
