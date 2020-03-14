using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WalletCore
{
  public class Auth
  {
    private readonly IRequest request;
    private readonly IDatabase database;
    private readonly Uri passwordSignOnUri;
    private readonly Uri abcUri;
    private readonly Regex guidRegex;

    public Auth(IRequest request, IDatabase database)
    {
      this.request = request;
      this.database = database;

      this.passwordSignOnUri = new Uri(request.BaseURI, "auth/authenticate/userpass");
      this.abcUri = new Uri(request.BaseURI, "ribeez/user/abc");
      this.guidRegex = new Regex(@"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}",
        RegexOptions.Compiled);
    }

    public async Task signInAsync(string username, string password)
    {
      var content = new MultipartFormDataContent();
      content.Add(new StringContent(username), "username");
      content.Add(new StringContent(password), "password");
      var response = await request.Client.PostAsync(passwordSignOnUri, content);
      response.EnsureSuccessStatusCode();
      var responseBody = await response.Content.ReadAsStringAsync();

      response = await request.Client.GetAsync(abcUri);
      response.EnsureSuccessStatusCode();
      responseBody = await response.Content.ReadAsStringAsync();

      var guids = guidRegex
        .Matches(responseBody)
        .Cast<Match>()
        .Select(x => Guid.Parse(x.Value))
        .ToList();

      this.database.Initialize(guids[2], guids[3]);
    }
  }
}