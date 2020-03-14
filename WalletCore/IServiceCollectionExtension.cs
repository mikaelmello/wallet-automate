using Microsoft.Extensions.DependencyInjection;

namespace WalletCore
{
  public static class IServiceCollectionExtension
  {

    public static IServiceCollection AddWalletCore(this IServiceCollection services)
    {
      services.AddScoped<Auth>();
      services.AddScoped<IRequest, Request>();
      services.AddScoped<IDatabase, Database>();
      return services;
    }
  }
}