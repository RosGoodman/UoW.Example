using SciMaterials.Data.Repositories;
using UoW.Example.DAL.Context;
using UoW.Example.DAL.Models;

namespace UoW.Example.DAL.Repositories;

public interface IEmployeeRepository : IRepository<Employee> { }
public class EmployeeRepository : IEmployeeRepository
{
    private readonly IContextDb _context;


    public EmployeeRepository(IContextDb context)
    {
        _context = context;
    }

    public void Add(Employee entity)
    {
        _context.Employees.Add(entity);
    }

    public Employee GetById(Guid id, bool disableTracking = true)
    {
        throw new NotImplementedException();
    }
}