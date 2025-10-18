using System.Data;

namespace ERPIN.Domain.IRepositories;
public interface IUnitOfWork : IDisposable
{
    public IItemRepository Items { get; }
    public IStoreRepository Stores {get; }
    public IItemStoreRepository ItemStores {get; }
    public IPrInvoiceRepository PRInvoices {get; }
    public IPrInvoiceDetailRepository PRInvoiceDetails {get; }
    public IPrReturnRepository PRReturns {get; }
    public IPrReturnDetailRepository PRReturnDetails {get; }
    public ISlInvoiceRepository SLInvoices {get; }
    public ISlInvoiceDetailRepository SLInvoiceDetails {get; }
    public ISlReturnRepository SLReturns {get; }
    public ISlReturnDetailRepository SLReturnDetails { get; }
    public IUserLogRepository UserLogs { get; }
    public ICustomerRepository Customers { get; }
    public IVendorRepository Vendors { get; }
    Task<int> SaveChangesAsync();
    IDbTransaction StartTransaction();
}
