using System;

namespace WalletCore.Models
{
  public class Record
  {
    public string Id { get; set; }
    public string Rev { get; set; }
    public string AccountId { get; set; }
    public long Accuracy { get; set; }
    public long Amount { get; set; }
    public string CategoryId { get; set; }
    public string CurrencyId { get; set; }
    public string fulltextString { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Note { get; set; }
    public string Payee { get; set; }
    public PaymentType PaymentType { get; set; }
    public string RecordDate { get; set; }
    public RecordState RecordState { get; set; }
    public long RefAmount { get; set; }
    public Guid ReservedAuthorId { get; set; }
    public string ReservedCreatedAt { get; set; }
    public string ReservedModelType { get { return "Record"; } }
    public Guid ReservedOwnerId { get; set; }
    public string ReservedSource { get; set; }
    public string ReservedUpdatedAt { get; set; }
    public string ReservedDeletedAt { get; set; }
    public string DeletedAt { get; set; }
    public bool _deleted { get; set; }
    public bool SoComplete { get; set; }
    public long SuggestedEnvelopeId { get; set; }
    public bool Transfer { get; set; }
    public RecordType Type { get; set; }
    public long WarrantyInMonth { get; set; }
  }
}