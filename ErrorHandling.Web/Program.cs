using ErrorHandling.Web.Filter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// application level exception handling
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new CustomHandleExceptionFilterAttribute() { ErrorPage = "CustomError1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

else
{
    app.UseDatabaseErrorPage();
    //app.UseExceptionHandler(context =>
    //{
    //    context.Run(async page =>
    //    {
    //        page.Response.StatusCode = 500;
    //        page.Response.ContentType = "text/html";
    //        await page.Response.WriteAsync($"<html><head><h1>There is an error: {page.Response.StatusCode}</h1></head></html>");
    //    });
    //}); 
    // app.UseStatusCodePages("text/plain", "There is an error. Status Code: {0}");
    app.UseStatusCodePages(async context =>
    {
        context.HttpContext.Response.ContentType = "text/plain";
        await context.HttpContext.Response.WriteAsync($"There is an error. StatusCode: {context.HttpContext.Response.StatusCode}");
    });
    // ASP.NET gives this by default
    // app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
