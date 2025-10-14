using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class PrInvoiceRepository : Repository<PrInvoice>, IPrInvoiceRepository
{
    public PrInvoiceRepository(AppDbContext context) : base(context)
    {
    }
}

