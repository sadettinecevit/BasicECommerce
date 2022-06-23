using BasicECommerce.Business.BusinessManagers.Abstract;
using BasicECommerce.Business.BusinessManagers.Concrete;
using BasicECommerce.DAL;
using BasicECommerce.DAL.Context.Concrete;
using BasicECommerce.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicECommerce.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection serviceCollection, IConfiguration configuration = null)
        {
            serviceCollection.AddDALService(configuration);

            serviceCollection.AddTransient<IAccountManager, AccountManager>();

            serviceCollection.AddIdentity<User, IdentityRole>()
                            .AddRoles<IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();
        }
    }
}