using SciMaterials.Data.Repositories;
using UoW.Example.DAL.Context;
using UoW.Example.DAL.Models;

namespace UoW.Example.DAL.Repositories;

public interface ICompanyRepository : IRepository<Company> { }
public class CompanyRepository : ICompanyRepository
{
    private readonly IContextDb _context;

    public CompanyRepository(IContextDb context)
    {
        _context = context;
    }

    public void Add(Company entity)
    {
        throw new NotImplementedException();
    }

    public Company GetById(Guid id, bool disableTracking = true)
    {
        throw new NotImplementedException();
    }
}