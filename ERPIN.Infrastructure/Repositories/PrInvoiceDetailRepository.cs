using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class PrInvoiceDetailRepository : Repository<PRInvoiceDetail>, IPrInvoiceDetailRepository
{
    public PrInvoiceDetailRepository(AppDbContext context) : base(context)
    {
    }
}
