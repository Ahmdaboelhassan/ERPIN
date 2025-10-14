using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SL;

[Table("SlInvoiceDetails", Schema = nameof(Schemes.SL))]
public class SlInvoiceDetail : InvoiceDetailEntity
{
}
