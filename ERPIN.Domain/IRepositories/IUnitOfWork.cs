using ERPIN.Domain.Entities.INV;
using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Entities.SL;
using System.Data;

namespace ERPIN.Domain.IRepositories;
public interface IUnitOfWork : IDisposable
{
    public IItemRepository Item  { get; }
    public IStoreRepository Store {get; }
    public IItemStoreRepository ItemStore {get; }
    public IPrInvoiceRepository PrInvoice {get; }
    public IPrInvoiceDetailRepository PrInvoiceDetail {get; }
    public IPrReturnRepository PrReturn {get; }
    public IPrReturnDetailRepository PrReturnDetail {get; }
    public ISlInvoiceRepository SlInvoice {get; }
    public ISlInvoiceDetailRepository SlInvoiceDetail {get; }
    public ISlReturnRepository SlReturn {get; }
    public ISlReturnDetailRepository SlReturnDetail { get;  }
    Task<int> SaveChangesAsync();
    IDbTransaction StartTransaction();
}
