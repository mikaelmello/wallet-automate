using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCouch;
using MyCouch.Requests;
using WalletCore.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WalletCore
{
  public class Records
  {
    private IMemoryCache cache;

    private readonly IDatabase database;

    public Records(IDatabase database, IMemoryCache memoryCache)
    {
      this.database = database;
      this.cache = memoryCache;
    }

    public async Task<IEnumerable<Record>> getAll()
    {
      if (cache.TryGetValue<List<Record>>("allRecords", out var records))
      {
        return records;
      }

      var query = new Query("_all_docs").Configure(q => q
        .StartKey("Record")
        .EndKey("Record\ufff0")
        .IncludeDocs(true)
        .Reduce(false));

      var result = await database.Store.QueryAsync<object, Record>(query);

      var list = result
        .Select(row => row.IncludedDoc)
        .ToList();

      var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromMinutes(10));

      cache.Set("allRecords", list, cacheEntryOptions);

      return list;
    }

    public async Task<IEnumerable<Record>> getByPayee(string payee)
    {
      var records = await getAll();

      return records
        .Where(r => r.Payee == payee);
    }

    public async Task addExpense(string date, long amount, string categoryId, string payee, string note,
        PaymentType paymentType, string accountId)
    {
      var baseRecord = (await getAll()).First();
      var record = new Record()
      {
        Id = $"Record_{Guid.NewGuid()}",
        AccountId = accountId,
        Accuracy = baseRecord.Accuracy,
        Amount = amount,
        CategoryId = categoryId,
        CurrencyId = baseRecord.CurrencyId,
        fulltextString = payee.ToLower() + note.ToLower(),
        Note = note,
        Payee = payee,
        PaymentType = paymentType,
        RecordDate = DateTime
          .ParseExact(date, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
          .ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        RecordState = RecordState.CLEARED,
        RefAmount = amount,
        ReservedAuthorId = baseRecord.ReservedAuthorId,
        ReservedCreatedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        ReservedOwnerId = baseRecord.ReservedOwnerId,
        ReservedSource = "web",
        ReservedUpdatedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
        SoComplete = baseRecord.SoComplete,
        SuggestedEnvelopeId = baseRecord.SuggestedEnvelopeId,
        Transfer = false,
        Type = RecordType.EXPENSE,
      };

      await database.Client.Documents.PutAsync(record.Id, JsonConvert.SerializeObject(record,
    new JsonSerializerSettings
    {
      ContractResolver = new CamelCasePropertyNamesContractResolver()
    }));
    }
  }
}