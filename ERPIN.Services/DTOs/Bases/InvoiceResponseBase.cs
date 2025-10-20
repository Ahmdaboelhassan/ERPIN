using ERPIN.Services.DTOs.Bases;

namespace ERPIN.Services.DTOs.Base;

public class InvoiceResponseBase
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? StoreId { get; set; }
    public decimal Paid { get; set; }
    public decimal Net { get; set; }
    public decimal Discount { get; set; }
    public decimal DiscountRatio { get; set; }
    public decimal Tax { get; set; }
    public decimal Remain { get; set; }
    public decimal Total { get; set; }

    public IList<InvoiceDetailResponseBase> InvoiceDetails { get; set; }
}
