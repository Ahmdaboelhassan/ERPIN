using ERPIN.Services.DTOs.Base;

namespace ERPIN.Services.DTOs.Response;
public class PRReturnResponse : InvoiceResponseBase
{
    public int? VendorId { get; set; }
}
