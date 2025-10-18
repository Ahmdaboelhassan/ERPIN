using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class PrInvoiceRepository : Repository<PRInvoice>, IPrInvoiceRepository
{
    public PrInvoiceRepository(AppDbContext context) : base(context)
    {
    }
}

