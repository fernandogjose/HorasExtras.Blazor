using Blazored.SessionStorage;
using HorasExtra.Application.AppServices;
using HorasExtra.Application.Interfaces;
using HorasExtra.Application.Mappers;
using HorasExtra.Blazor.Helpers;
using HorasExtra.Blazor.PagesServices;
using HorasExtra.Blazor.Providers;
using HorasExtra.Domain.Interfaces.Repositories;
using HorasExtra.Domain.Interfaces.Services;
using HorasExtra.Domain.Services;
using HorasExtra.Domain.Validacoes;
using HorasExtra.Repository.Helpers;
using HorasExtra.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace HorasExtra.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredSessionStorage();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddSingleton<CryptHelper>();

            services.AddTransient<HorasPageService>();
            services.AddTransient<LoginPageService>();
            services.AddTransient<UsuarioPageService>();

            services.AddTransient<LoginMapper>();
            services.AddTransient<ErroMapper>();
            services.AddTransient<HorasMapper>();

            services.AddTransient<IHorasAppService, HorasAppService>();
            services.AddTransient<ILoginAppService, LoginAppService>();
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();

            services.AddTransient<LoginValidacao>();

            services.AddTransient<IHorasService, HorasService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddSingleton<MongoHelper>();
            services.AddTransient<IHorasRepository, HorasRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Definindo a cultura padrão: pt-BR
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts(); // aka.ms/aspnetcore-hsts.
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
