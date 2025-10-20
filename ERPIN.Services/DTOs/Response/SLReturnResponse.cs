using ERPIN.Services.DTOs.Base;

namespace ERPIN.Services.DTOs.Response;
public class SLReturnResponse : InvoiceResponseBase
{
    public int? CustomerId { get; set; }
}
