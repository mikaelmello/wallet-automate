using System;

namespace WalletCore.Models
{
  public class Account
  {
    public string Id { get; set; }
    public string Rev { get; set; }
    public string Color { get; set; }
    public AccountType AccountType { get; set; }
    public Guid ReservedOwnerId { get; set; }
    public DateTime ReservedUpdatedAt { get; set; }
    public bool Gps { get; set; }
    public bool Archived { get; set; }
    public bool ExcludeFromStats { get; set; }
    public Guid ReservedAuthorId { get; set; }
    public DateTime ReservedCreatedAt { get; set; }
    public string ReservedModelType { get { return "Account"; } }
    public string ReservedSource { get; set; }
    public string Name { get; set; }
    public long Position { get; set; }
    public string CurrencyId { get; set; }
    public long InitAmount { get; set; }
    public long InitRefAmount { get; set; }
  }
}