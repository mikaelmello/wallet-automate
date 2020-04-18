using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WalletCore.Models;
using WalletCore.Services;

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
      var records = serviceProvider.GetService<Records>();
      var categories = serviceProvider.GetService<Categories>();
      var accounts = serviceProvider.GetService<Accounts>();
      var currencies = serviceProvider.GetService<Currencies>();
      var db = serviceProvider.GetService<IDatabase>();
      var csv = serviceProvider.GetService<CsvImporter>();

      // any passwords in the commit history are already reset ;)
      await auth.signInAsync("", "");
      var nubank = await accounts.getByName("Nubank");
      var brl = await currencies.getByCode("BRL");
      var envelopeId = 0;

      await records.add("2020-03-20T15:45:27Z",
        700,
        StandardCategories.FOOD__GROCERIES,
        "Local Market",
        "Food",
        PaymentType.CREDIT_CARD,
        brl.Id,
        nubank.Id,
        envelopeId,
        RecordType.EXPENSE);
      await records.add("2020-03-19T21:06:02Z",
        2800,
        StandardCategories.TRANSPORTATION__TAXI,
        "Uber",
        "Place 1 to Place 2",
        PaymentType.CREDIT_CARD,
        brl.Id,
        nubank.Id,
        envelopeId,
        RecordType.EXPENSE);
    }
  }
}