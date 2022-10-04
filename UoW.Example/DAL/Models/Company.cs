
using System.ComponentModel.DataAnnotations;

namespace UoW.Example.DAL.Models;

public class Company
{
    [Key]
    public Guid Id { get; set; }
    public string? CompanyName { get; set; }
    public List<Employee>? Users { get; set; }
}