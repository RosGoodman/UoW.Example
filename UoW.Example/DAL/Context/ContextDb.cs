#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using UoW.Example.DAL.Models;

namespace UoW.Example.DAL.Context;

public class ContextDb : DbContext, IContextDb
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Company> Companies { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var directory = Directory.GetCurrentDirectory();
        optionsBuilder.UseSqlite("Filename=Database.db", option =>
        {
            option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => base.OnModelCreating(modelBuilder);

    //т.к. в репозитории передается интерфейс, то необхоимо прописывать используемые методы

    public IDbContextTransaction GetCurrentTransaction() => Database.CurrentTransaction;
    public IDbContextTransaction ContextBeginTransaction() => Database.BeginTransaction();

    public int ContextSaveChanges() => SaveChanges();
}