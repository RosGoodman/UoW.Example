using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UoW.Example.DAL.Models;

namespace UoW.Example.DAL.Context
{
    public interface IContextDb
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Employee> Employees { get; set; }

        int ContextSaveChanges();
        IDbContextTransaction ContextBeginTransaction();
        IDbContextTransaction GetCurrentTransaction();

        void Dispose();
    }
}