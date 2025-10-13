namespace ERPIN.Shared.Models.IModels;

public interface IInvoiceEntity
{
    public string? Note { get; set; }
    public decimal Paid { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public decimal Tax { get; set; }
    public decimal Remain { get; set; }
    public int? StoreId { get; set; }
}
