using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace ERPIN.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public IItemRepository Items => new ItemRepository(_context);

    public IStoreRepository Stores => new StoreRepository(_context);

    public IItemStoreRepository ItemStores=> new ItemStoreRepository(_context);

    public IPrInvoiceRepository PRInvoices => new PrInvoiceRepository(_context);

    public IPrInvoiceDetailRepository PRInvoiceDetails => new PrInvoiceDetailRepository(_context);

    public IPrReturnRepository PRReturns => new PrReturnRepository(_context);

    public IPrReturnDetailRepository PRReturnDetails => new PrReturnDetailRepository(_context);

    public ISlInvoiceRepository SLInvoices => new SlInvoiceRepository(_context);

    public ISlInvoiceDetailRepository SLInvoiceDetails => new SlInvoiceDetailRepository(_context);

    public ISlReturnRepository SLReturns => new SlReturnRepository(_context);

    public ISlReturnDetailRepository SLReturnDetails => new SlReturnDetailRepository(_context);
    public IUserLogRepository UserLogs => new UserLogRepository(_context);

    public ICustomerRepository Customers => new CustomerRepository(_context);

    public IVendorRepository Vendors => new VendorRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IDbTransaction StartTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
    public void Dispose()
    {
       _context.Dispose();
    }

    
}
