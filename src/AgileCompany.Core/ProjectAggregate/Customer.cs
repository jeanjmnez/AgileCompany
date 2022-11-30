using System.Xml.Linq;
using AgileCompany.Core.ProjectAggregate.Events;
using AgileCompany.SharedKernel;
using Ardalis.GuardClauses;

namespace AgileCompany.Core.ProjectAggregate;

public class Customer : EntityBase
{
  public Customer(string  name,string address,string city)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
   
  }
  public string Name { get; private set; }

  private List<Address> _address = new List<Address>();
  public IEnumerable<Address> Addresses => _address.AsReadOnly();

  
}
