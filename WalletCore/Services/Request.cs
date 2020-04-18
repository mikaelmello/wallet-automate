using System;
using System.Net.Http;

namespace WalletCore.Services
{
  public interface IRequest
  {
    HttpClient Client { get; }
    Uri BaseURI { get; }
  }

  public class Request : IRequest
  {
    private readonly HttpClient _client = new HttpClient();
    private readonly Uri _baseURI = new Uri("https://api.budgetbakers.com");
    public HttpClient Client { get { return _client; } }
    public Uri BaseURI { get { return _baseURI; } }
  }
}