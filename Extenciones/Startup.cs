using Microsoft.AspNetCore.Authentication.Cookies;

namespace BODEGA_SOLORZANO.Extenciones
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ... otros servicios configurados ...

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "YourAppName.AuthCookie";
                    options.LoginPath = "/Account/Login"; // La ruta a la página de inicio de sesión
                });

            // ... más configuraciones ...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ... otras configuraciones de middleware ...

            app.UseAuthentication();
            app.UseAuthorization();

            // ... más configuraciones de middleware ...
        }


    }
}
