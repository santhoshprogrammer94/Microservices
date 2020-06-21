namespace PetFoodShop.Identity
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PetFoodShop.Identity.Data;
    using PetFoodShop.Identity.Infrastructure.Extensions;
    using PetFoodShop.Infrastructure.Extensions;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<AppIdentityDbContext>(this.Configuration)
                .AddUserStorage()
                .AddApplicationServices();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .ApplyMigration<AppIdentityDbContext>();
    }
}
