using ERPIN.Domain.BaseModels.IModels;
using System.ComponentModel.DataAnnotations;

namespace ERPIN.Domain.BaseModels;
public class InvoiceEntity : IInvoiceEntity, IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public int Code { get; set; }
    public string? Note { get; set; }
    public int? StoreId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdateBy { get; set; }
    public int? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }
    public decimal Paid { get; set; }
    public decimal Net { get; set; }
    public decimal Discount { get; set; }
    public decimal DiscountRatio { get; set; }
    public decimal Tax { get; set; }
    public decimal Remain { get; set; }
    public decimal Total { get; set; }
}
