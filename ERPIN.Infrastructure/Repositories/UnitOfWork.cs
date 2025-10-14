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
    public IItemRepository Item => new ItemRepository(_context);

    public IStoreRepository Store => new StoreRepository(_context);

    public IItemStoreRepository ItemStore => new ItemStoreRepository(_context);

    public IPrInvoiceRepository PrInvoice => new PrInvoiceRepository(_context);

    public IPrInvoiceDetailRepository PrInvoiceDetail => new PrInvoiceDetailRepository(_context);

    public IPrReturnRepository PrReturn => new PrReturnRepository(_context);

    public IPrReturnDetailRepository PrReturnDetail => new PrReturnDetailRepository(_context);

    public ISlInvoiceRepository SlInvoice => new SlInvoiceRepository(_context);

    public ISlInvoiceDetailRepository SlInvoiceDetail => new SlInvoiceDetailRepository(_context);

    public ISlReturnRepository SlReturn => new SlReturnRepository(_context);

    public ISlReturnDetailRepository SlReturnDetail => new SlReturnDetailRepository(_context);

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
