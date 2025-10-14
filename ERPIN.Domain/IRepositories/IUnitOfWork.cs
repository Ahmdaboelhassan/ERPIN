using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Entities.SL;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ERPIN.Domain.IRepositories;
public interface IUnitOfWork : IDisposable
{
    public IItemRepository Items { get; }
    public IStoreRepository Stores {get; }
    public IItemStoreRepository ItemStores {get; }
    public IPrInvoiceRepository PrInvoices {get; }
    public IPrInvoiceDetailRepository PrInvoiceDetails {get; }
    public IPrReturnRepository PrReturns {get; }
    public IPrReturnDetailRepository PrReturnDetails {get; }
    public ISlInvoiceRepository SlInvoices {get; }
    public ISlInvoiceDetailRepository SlInvoiceDetails {get; }
    public ISlReturnRepository SlReturns {get; }
    public ISlReturnDetailRepository SlReturnDetails { get; }
    public IUserLogRepository UserLogs { get; }
    Task<int> SaveChangesAsync();
    IDbTransaction StartTransaction();
}
