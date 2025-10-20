using ERPIN.Services.DTOs.Bases;

namespace ERPIN.Services.DTOs.Request;
public class CreatePRInvoice : CreateInvoiceBase
{
    public int? VendorId { get; set; }  
}


