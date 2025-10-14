using ERPIN.Domain.BaseModels;
using ERPIN.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPIN.Domain.Entities.SL;

[Table("Customers", Schema = nameof(Schemes.SL))]
public class Customer : BaseEntity
{
}

