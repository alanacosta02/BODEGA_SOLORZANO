using Microsoft.AspNetCore.Authentication.Cookies; // Para controlador acceso part1

var builder = WebApplication.CreateBuilder(args);

// Agregamos la autenticacion al proyecto usando cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

        //options.LogoutPath = "/Acceso/CerrarSesion";
        //options.AccessDeniedPath = "/Acceso/Denegado";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Activar para autenticacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");
pattern: "{controller=Pedido}/{action=Listar}/{id?}");

app.Run();
