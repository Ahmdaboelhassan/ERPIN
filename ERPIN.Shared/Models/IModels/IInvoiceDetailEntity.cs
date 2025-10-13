using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Shared.Models.IModels;
public interface IInvoiceDetailEntity
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountRation1 { get; set; }
    public decimal DiscountRation2 { get; set; }
    public decimal DiscountRation3 { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; }
    public int InvoiceId { get; set; }
}
