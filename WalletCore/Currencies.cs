using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCouch;
using MyCouch.Requests;
using WalletCore.Models;
using Microsoft.Extensions.Caching.Memory;

namespace WalletCore
{
  public class Currencies
  {
    private IMemoryCache cache;

    private readonly IDatabase database;

    public Currencies(IDatabase database, IMemoryCache memoryCache)
    {
      this.database = database;
      this.cache = memoryCache;
    }

    public async Task<List<Currency>> getAll()
    {
      if (cache.TryGetValue<List<Currency>>("allRecords", out var currencies))
      {
        return currencies;
      }

      var query = new Query("_all_docs").Configure(q => q
        .StartKey("-Currency")
        .EndKey("-Currency\ufff0")
        .IncludeDocs(true)
        .Reduce(false));

      var result = await database.Store.QueryAsync<object, Currency>(query);

      var list = result.Select(row => row.IncludedDoc).ToList();

      var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromMinutes(10));

      foreach (var currency in list)
      {
        cache.Set(currency.Code, currency, cacheEntryOptions);
      }

      cache.Set("allRecords", list, cacheEntryOptions);

      return list;
    }

    public async Task<Currency> getByCode(string code)
    {
      if (!cache.TryGetValue<Currency>(code, out var currency))
      {
        await getAll();
        currency = cache.Get<Currency>(code);
      }

      return currency ?? throw new ArgumentException($"Currency with code {code} not found");
    }
  }
}