using ERPIN.Services.DTOs.Base;

namespace ERPIN.Services.DTOs.Response;

public class PRInvoiceResponse : InvoiceResponseBase
{ 
    public int? VendorId { get; set; }
}
