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
  }
}