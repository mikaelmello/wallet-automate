﻿using System;
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
      var accounts = serviceProvider.GetService<Accounts>();
      await auth.signInAsync("mikaelmmello@gmail.com", "10BnpJTB!7TV@rW*icFf&5");
      var x = await accounts.getByName("Banco Inter");
      Console.WriteLine(x.InitAmount);
      Console.WriteLine("Hello World!");
    }
  }
}