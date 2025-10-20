using ERPIN.Services.DTOs.Bases;

namespace ERPIN.Services.DTOs.Request;
public class CreateSLInvoice : CreateInvoiceBase
{
    public int? CustomerId { get; set; }
}



