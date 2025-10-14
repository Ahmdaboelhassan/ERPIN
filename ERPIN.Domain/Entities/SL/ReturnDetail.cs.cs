using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SL;

[Table("SlReturnDetails", Schema = nameof(Schemes.SL))]
public class SlReturnDetail : InvoiceDetailEntity
{
}
