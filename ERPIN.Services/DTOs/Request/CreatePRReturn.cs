using ERPIN.Services.DTOs.Bases;

namespace ERPIN.Services.DTOs.Request;
 
public class CreatePRReturn : CreateInvoiceBase
{
    public int? VendorId { get; set; }
}
