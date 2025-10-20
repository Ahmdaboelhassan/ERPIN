namespace ERPIN.Services.DTOs.Response;
public class InvoiceItemResponse
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Name { get; set; }
    public string? NameEn { get; set; }
    public string? BarCode { get; set; }
    public string? Description { get; set; }
    public string? UOM { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? SellPrice { get; set; }
   
}
