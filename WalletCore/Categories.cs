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
  public class Categories
  {
    private IMemoryCache cache;

    private readonly IDatabase database;

    public Categories(IDatabase database, IMemoryCache memoryCache)
    {
      this.database = database;
      this.cache = memoryCache;
    }

    public async Task<IEnumerable<Category>> getAll()
    {
      if (cache.TryGetValue<List<Category>>("allRecords", out var categories))
      {
        return categories;
      }

      var query = new Query("_all_docs").Configure(q => q
        .StartKey("-Category")
        .EndKey("-Category\ufff0")
        .IncludeDocs(true)
        .Reduce(false));

      var result = await database.Store.QueryAsync<object, Category>(query);

      var list = result
        .Select(row => row.IncludedDoc)
        .ToList();

      var cacheEntryOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromMinutes(10));

      foreach (var category in list)
      {
        cache.Set($"NAME-{category.Name}", category, cacheEntryOptions);
        cache.Set($"ID-{category.Id}", category, cacheEntryOptions);
      }

      cache.Set("allRecords", list, cacheEntryOptions);

      return list;
    }

    public async Task<Category> getById(string id)
    {
      if (!cache.TryGetValue<Category>($"ID-{id}", out var category))
      {
        category = await database.Store.GetByIdAsync<Category>(id);

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(10));

        cache.Set($"ID-{category.Id}", category, cacheEntryOptions);
      }

      return category ?? throw new ArgumentException($"Category with id {id} not found");
    }

    public async Task<Category> getByName(string name)
    {
      if (!cache.TryGetValue<Category>($"NAME-{name}", out var category))
      {
        await getAll();
        category = cache.Get<Category>($"NAME-{name}");
      }

      return category ?? throw new ArgumentException($"Category with name {name} not found");
    }
  }
}