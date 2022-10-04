using Microsoft.EntityFrameworkCore.Storage;
using SciMaterials.DAL.UnitOfWork;
using SciMaterials.Data.Repositories;
using UoW.Example.DAL.Context;
using UoW.Example.DAL.Models;
using UoW.Example.DAL.Repositories;

namespace SciMaterials.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IContextDb _context;

    private bool disposed;
    private Dictionary<Type, object>? _repositories;

    /// <summary> ctor. </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    /// <exception cref="ArgumentException"></exception>
    public UnitOfWork(IContextDb context)
    {
        _context = context ?? throw new ArgumentException(nameof(context));
    }

    ///
    /// <inheritdoc cref="IUnitOfWork{T}.GetRepository{TEntity}"/>
    public IRepository<T> GetRepository<T>() where T : class
    {
        if (_repositories == null)
            _repositories = new Dictionary<Type, object>();

        var type = typeof(T);

        if (!_repositories.ContainsKey(type))
        {
            if (type == typeof(Employee))
                _repositories.Add(type, new EmployeeRepository(_context));
            else if (type == typeof(Company))
                _repositories.Add(type, new CompanyRepository(_context));
        }
        return (IRepository<T>)_repositories[type];
    }

    ///
    /// <inheritdoc cref="IUnitOfWork{T}.SaveContext()"/>
    public int SaveChanges() => _context.ContextSaveChanges();

    ///
    /// <inheritdoc cref="IUnitOfWork{T}.SaveContextAsync()"/>
    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    ///
    /// <inheritdoc cref="IUnitOfWork{T}.BeginTransaction(bool)"/>
    public IDbContextTransaction BeginTransaction(bool useIfExists = false)
    {
        var transaction = _context.GetCurrentTransaction();
        if (transaction == null)
        {
            return _context.ContextBeginTransaction();
        }

        return useIfExists ? transaction : _context.ContextBeginTransaction();
    }

    ///
    /// <inheritdoc cref="IUnitOfWork{T}.BeginTransactionAsync(bool)"/>
    public Task<IDbContextTransaction> BeginTransactionAsync(bool useIfExists = false)
    {
        throw new NotImplementedException();
    }

    #region Dispose

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            disposed = true;
        }
    }

    #endregion
}