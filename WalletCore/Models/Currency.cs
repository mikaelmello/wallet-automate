using System;

namespace WalletCore.Models
{
  public class Currency
  {
    public string Id { get; set; }
    public string Rev { get; set; }
    public string Code { get; set; }
    public Guid ReservedOwnerId { get; set; }
    public DateTime ReservedUpdatedAt { get; set; }
    public DateTime ReservedCreatedAt { get; set; }
    public DateTime ReservedDeletedAt { get; set; }
    public Guid ReservedAuthorId { get; set; }
    public string ReservedModelType { get { return "Currency"; } }
    public string ReservedSource { get; set; }
    public string ReservedDeletedSource { get; set; }
    public double RatioToReferential { get; set; }
    public bool Referential { get; set; }
    public long Position { get; set; }
    public string Name { get; set; }
    public bool _deleted { get; set; }
  }
}