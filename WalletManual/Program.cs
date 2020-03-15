using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WalletCore;
using WalletCore.Models;

namespace WalletManual
{
  class Program
  {
    static async Task Main(string[] args)
    {
      //setup our DI
      var serviceProvider = new ServiceCollection()
          .AddLogging()
          .AddWalletCore()
          .BuildServiceProvider();

      //do the actual work here
      var auth = serviceProvider.GetService<Auth>();
      var accounts = serviceProvider.GetService<Records>();
      var categories = serviceProvider.GetService<Categories>();
      await auth.signInAsync("mikaelmmello@gmail.com", "10BnpJTB!7TV@rW*icFf&5");
      var x = await accounts.getByPayee("Eu");
      var cat = await categories.getById("-Category_12d113de-d32e-4b8d-a636-d00438027cb2");
      Console.WriteLine(cat.Name);
      foreach (var r in x)
      {
        Console.WriteLine($"{r.CategoryId} {r.Note}");
      }
      Console.WriteLine("Hello World!");
    }
  }
}