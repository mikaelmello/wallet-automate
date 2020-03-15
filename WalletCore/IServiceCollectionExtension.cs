using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace WalletCore
{
  public static class IServiceCollectionExtension
  {

    public static IServiceCollection AddWalletCore(this IServiceCollection services)
    {
      services.AddMemoryCache();

      services.AddScoped<Auth>();
      services.AddScoped<Accounts>();
      services.AddScoped<Categories>();
      services.AddScoped<Currencies>();
      services.AddScoped<IRequest, Request>();
      services.AddScoped<IDatabase, Database>();
      return services;
    }
  }
}