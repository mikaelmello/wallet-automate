using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using WalletCore.Models;

namespace WalletCore
{
  public class CsvImporter
  {
    private readonly Accounts accounts;
    private readonly Currencies currencies;
    private readonly Records records;

    public CsvImporter(Accounts accounts, Currencies currencies, Records records)
    {
      this.accounts = accounts;
      this.currencies = currencies;
      this.records = records;
    }

    public async Task Import(string path)
    {
      using (var reader = new StreamReader(path))
      using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        Delimiter = ";",
      }))
      {
        var list = csv.GetRecords<CsvRecord>().ToList();
        IProgress<CsvRecord> progress = new Progress<CsvRecord>(i =>
            Console.WriteLine($"Finished {i.Account} {i.Amount} {i.Date}"));

        await list.ForEachAsync<CsvRecord>(30, async record =>
        {
          var accountId = (await accounts.getByName(record.Account)).Id;
          var categoryId = StandardCategories.getIdFromName(record.Category);
          var currencyId = (await currencies.getByCode(record.Currency)).Id;
          var amount = long.Parse(string.Join("", record.Amount.Split(',')));
          var date = DateTime.ParseExact(record.Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            .AddHours(3)
            .ToString("yyyy-MM-ddTHH:mm:ssZ");

          if (amount > 0)
          {
            await records.add(date, amount, categoryId, record.Payee, record.Note, record.PaymentType, currencyId,
                accountId, record.EnvelopeId, RecordType.INCOME);
          }
          else
          {
            amount *= -1;
            await records.add(date, amount, categoryId, record.Payee, record.Note, record.PaymentType, currencyId,
                accountId, record.EnvelopeId, RecordType.EXPENSE);
          }
        }, progress);
      }
    }
  }
}