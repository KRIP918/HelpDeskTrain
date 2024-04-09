using HelpDeskTrain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*builder.Services.AddEndpointsApiExplorer();*/
builder.Services.AddMvc(mvc => { mvc.EnableEndpointRouting = false; });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/LogoOff";
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
}*/

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

//app.UseEndpoints();
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controler = App}/{action =Index}/{id?}");
    routes.MapRoute("NotFound", "{*url}",
        new { controller = "App", action = "RedirectToMain" });

});

app.MapControllers();

app.Run();
