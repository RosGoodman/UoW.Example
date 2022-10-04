
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoW.Example.DAL.Models;

public class Employee
{
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public Guid CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    public Company? Company { get; set; }
}