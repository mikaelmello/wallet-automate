using System;
using System.Net.Http;
using MyCouch;

namespace WalletCore
{
  public interface IDatabase
  {
    MyCouchClient Client { get; }
    MyCouchStore Store { get; }
    void Initialize(Guid dbUser, Guid dbPassword);
  }

  public class Database : IDatabase, IDisposable
  {
    private Guid dbUser;
    private Guid dbPassword;
    private string dbName { get { return $"bb-{dbUser}"; } }
    private readonly Uri databaseUri = new Uri("https://couch-prod-ams-3.budgetbakers.com");
    private MyCouchClient client = null;
    private MyCouchStore store = null;

    public MyCouchClient Client
    {
      get => client ?? throw new AppDomainUnloadedException("Uninitialized database client");
    }
    public MyCouchStore Store
    {
      get => store ?? throw new AppDomainUnloadedException("Uninitialized database store");
    }

    public void Initialize(Guid dbUser, Guid dbPassword)
    {
      this.dbUser = dbUser;
      this.dbPassword = dbPassword;

      var info = new DbConnectionInfo(databaseUri, dbName);
      info.BasicAuth = new MyCouch.Net.BasicAuthString(dbUser.ToString(), dbPassword.ToString());

      this.client = new MyCouchClient(info);
      this.store = new MyCouchStore(this.client);
    }

    public void Dispose()
    {
      this.client.Dispose();
      this.store.Dispose();
    }
  }
}