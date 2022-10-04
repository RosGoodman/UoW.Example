
using SciMaterials.DAL.UnitOfWork;
using UoW.Example.DAL.Models;

namespace UoW.Example.Usage;

internal class ClassUsingUoW
{
    private IUnitOfWork _unitOfWork { get; }

    /*при необходимости получить любые репозитории прокидывается UoW*/
    public ClassUsingUoW(IUnitOfWork unitOfWork)
	{
        _unitOfWork = unitOfWork;
	}

	public void SomeMethodOne()
    {
        var company = new Company()
        {
            CompanyName = "Apple"
        };

        var employee = new Employee() 
        { 
            Name = "Ivan", 
            Age = 123,
            Company = company,
        };

        //получение репозитория
        var employeeRepository = _unitOfWork.GetRepository<Employee>();

        //метод Add
        employeeRepository.Add(employee);

        //сохранение происходит там, где получили экземпляр репозитория
        _unitOfWork.SaveChanges();
    }
}