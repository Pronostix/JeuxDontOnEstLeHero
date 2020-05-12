using JeuxDontOnEstLeHero.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JeuxDontOnEstLeHero.BackOffice.Web.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddAuthentication().AddFacebook(option =>
            {
                // Récupération de l'identifiant de l'authentification Facebook
                // Faire ça uniquement pour les tests, sinon dans les variables d'environnement du serveur
                option.AppId = this.Configuration["apis:facebook:id"];
                option.AppSecret = this.Configuration["apis:facebook:secretKey"];
            });

            // Récupération de la chaine de connexion
            string connexionString = this.Configuration.GetConnectionString("DefaultContext_Local");

            // Injection de dépendance : lors de l'appel du constructeur DefaultContext, on injecte UseSqlServer à chaque appel
            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(connexionString), ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            // Mise en place des routes du site
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Quest}/{action=List}");
            });
        }
    }
}
