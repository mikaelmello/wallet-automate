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
  public class Accounts
  {
    private IMemoryCache cache;

    private readonly IDatabase database;

    public Accounts(IDatabase database, IMemoryCache memoryCache)
    {
      this.database = database;
      this.cache = memoryCache;
    }

    public async Task<List<Account>> getAll()
    {
      var query = new Query("_all_docs").Configure(q => q
        .StartKey("-Account")
        .EndKey("-Account\ufff0")
        .IncludeDocs(true)
        .Reduce(false));

      var result = await database.Store.QueryAsync<object, Account>(query);

      var list = result.Select(row => row.IncludedDoc).ToList();

      var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromMinutes(10));

      foreach (var account in list)
      {
        cache.Set(account.Name, account, cacheEntryOptions);
      }

      return list;
    }

    public async Task<Account> getByName(string name)
    {
      if (!cache.TryGetValue<Account>(name, out var account))
      {
        await getAll();
        account = cache.Get<Account>(name);
      }

      return account;
    }
  }
}