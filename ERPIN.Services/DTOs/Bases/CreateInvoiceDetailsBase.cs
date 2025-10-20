namespace ERPIN.Services.DTOs.Bases;
public class CreateInvoiceDetailsBase
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountRation1 { get; set; }
    public decimal DiscountRation2 { get; set; }
    public decimal DiscountRation3 { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; }
    public int InvoiceId { get; set; }
}
