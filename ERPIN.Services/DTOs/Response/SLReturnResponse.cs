using ERPIN.Domain.BaseModels.IModels;

namespace ERPIN.Services.DTOs.Response;
public class SLReturnResponse
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string? Note { get; set; }
    public string CreatedAt { get; set; }
    public decimal Paid { get; set; }
    public decimal Net { get; set; }
    public decimal Discount { get; set; }
    public decimal DiscountRatio { get; set; }
    public decimal Tax { get; set; }
    public decimal Remain { get; set; }
    public decimal Total { get; set; }

    public IList<SLReturnDetailResponse> InvoiceDetails { get; set; }
}

public class SLReturnDetailResponse
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
