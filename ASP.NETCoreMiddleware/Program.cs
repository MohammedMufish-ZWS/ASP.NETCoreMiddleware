var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/big", big);
static void big(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("I am a big stepper.");
    });
}

//if u execute above code it will map / route & will give Hello World
//app.MapDefaultControllerRoute(big);
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello World\n");
    await next(context);
});
//use() places a middleware in the pipeline and allows that middleware to pass control to next item in the pipeline.
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
//after executing run you can't excute subsequent middleware

app.Run();
