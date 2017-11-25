using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;

namespace Vidly.Models
{
    //public interface IAPICustomerRepository
    //{

    //    IHttpActionResult GetCustomers(string query = null);
    //    IHttpActionResult GetCustomer(int id);
    //    IHttpActionResult CreateCustomer(CustomerDto customerDto);
    //    IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto);
    //    IHttpActionResult DeleteCustomer(int id);
    //}
    public interface IAPICustomerRepository
    {
        IEnumerable<CustomerDto> GetCustomers(string query = null);
        CustomerDto GetCustomer(int id);
        int CreateCustomer(CustomerDto customerDto);
        CustomerDto UpdateCustomer(int id, CustomerDto customerDto);
        bool? DeleteCustomer(int id);
    }
}