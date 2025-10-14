namespace ERPIN.Services.DTOs.Request;
public class CreateSLReturn 
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string? Note { get; set; }
    public int? StoreId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Paid { get; set; }
    public decimal Net { get; set; }
    public decimal Discount { get; set; }
    public decimal DiscountRatio { get; set; }
    public decimal Tax { get; set; }
    public decimal Remain { get; set; }
    public decimal Total { get; set; }
    public IList<CreateSLReturnDetail> ReturnDetails { get; set; }
}

public class CreateSLReturnDetail
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

