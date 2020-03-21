using CsvHelper.Configuration.Attributes;

namespace WalletCore.Models
{
  public class CsvRecord
  {
    [Name("account")]
    public string Account { get; set; }
    [Name("category")]
    public string Category { get; set; }
    [Name("currency")]
    public string Currency { get; set; }
    [Name("amount")]
    public string Amount { get; set; }
    [Name("payment_type")]
    public PaymentType PaymentType { get; set; }
    [Name("note")]
    public string Note { get; set; }
    [Name("payee")]
    public string Payee { get; set; }
    [Name("date")]
    public string Date { get; set; }
    [Name("transfer")]
    public bool Transfer { get; set; }
    [Name("envelope_id")]
    public long EnvelopeId { get; set; }
  }
}