using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }
        Customer Save(Customer customer);
        Customer Edit(int id);
        Customer Details(int id);
    }
}
