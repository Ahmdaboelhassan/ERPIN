﻿using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ERPIN.Shared.Repositories.IRepositories;
public interface IRepository<T,Context>
{
    // Queries
    Task<T?> Get(int id);
    Task<T?> Get(Expression<Func<T, bool>> criteria, params string[] includes);
    Task<T?> GetFirst(params string[] includes);
    Task<T?> GetLast(Expression<Func<T, bool>> criteria, params string[] includes);
    Task<T?> GetLastOrderBy<Key>(Expression<Func<T, Key>> orderBy, params string[] includes);
    Task<List<T>> GetAll(params string[]? includes);
    Task<List<T>> GetAll(Expression<Func<T, bool>> criteria, params string[]? includes);
    Task<IEnumerable<O>> SelectAll<O>(Expression<Func<T, bool>> criteria, Expression<Func<T, O>> columns, params string[]? includes);
    Task<IEnumerable<O>> SelectSome<O, K>(Expression<Func<T, bool>> criteria, Expression<Func<T, O>> columns, Expression<Func<T, K>> orderBy, int pageNum, int pageSize, params string[]? includes);
    Task<IEnumerable<O>> TakeLastOrderBy<O, K>(int takeCount, Expression<Func<T, O>> columns, Expression<Func<T, K>> orderBy);
    IQueryable<T> AsQueryable();
    Task<bool> Exists(Expression<Func<T, bool>>? criteria = null);
    Task<int> Count(Expression<Func<T, bool>> criteria);
    Task<decimal> Sum(Expression<Func<T, decimal>> criteria);

    // Command
    void Add(T element);
    Task AddAsync(T element);
    Task AddRange(IEnumerable<T> element);
    void Delete(T element);
    void Update(T element);
    void DeleteRange(IEnumerable<T> items);
    void UpdateRange(IEnumerable<T> items);
    Task ExecuteUpdateAsync(Expression<Func<T, bool>> criteria, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> update);
}
