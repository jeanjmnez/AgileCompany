using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCompany.SharedKernel;
using Ardalis.GuardClauses;

namespace AgileCompany.Core.ProjectAggregate;
public class Company: EntityBase
{
  public Company(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }
 
  private List<Customer> _customers = new List<Customer>();
  public IEnumerable<Customer> Customers => _customers.AsReadOnly();
  public string Name { get; private set; }
  public CompanyType Type { get; set; }
 
}
