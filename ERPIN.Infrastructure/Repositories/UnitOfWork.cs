using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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

    public IPrInvoiceRepository PrInvoices => new PrInvoiceRepository(_context);

    public IPrInvoiceDetailRepository PrInvoiceDetails => new PrInvoiceDetailRepository(_context);

    public IPrReturnRepository PrReturns => new PrReturnRepository(_context);

    public IPrReturnDetailRepository PrReturnDetails => new PrReturnDetailRepository(_context);

    public ISlInvoiceRepository SlInvoices => new SlInvoiceRepository(_context);

    public ISlInvoiceDetailRepository SlInvoiceDetails => new SlInvoiceDetailRepository(_context);

    public ISlReturnRepository SlReturns => new SlReturnRepository(_context);

    public ISlReturnDetailRepository SlReturnDetails => new SlReturnDetailRepository(_context);
    public IUserLogRepository UserLogs => new UserLogRepository(_context);

    public void Dispose()
    {
       _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public IDbTransaction StartTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}
