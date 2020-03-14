using System;

namespace WalletCore.Models
{
  public class Category
  {
    public string Id { get; set; }
    public string Rev { get; set; }
    public string Color { get; set; }
    public bool CustomCategory { get; set; }
    public bool CustomName { get; set; }
    public RecordType DefaultType { get; set; }
    public string Desc { get; set; }
    public string EnvelopeId { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }
    public long Position { get; set; }
    public Guid ReservedOwnerId { get; set; }
    public DateTime ReservedUpdatedAt { get; set; }
    public DateTime ReservedDeletedAt { get; set; }
    public Guid ReservedAuthorId { get; set; }
    public string ReservedModelType { get { return "Category"; } }
    public string ReservedSource { get; set; }
    public string ReservedDeletedSource { get; set; }
    public bool _deleted { get; set; }
  }
}