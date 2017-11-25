using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Collections.Generic;

namespace Vidly.Models
{

    public class EFApiCustomerController : ApiController, IAPICustomerRepository 
    {
        private ApplicationDbContext _context;

        public EFApiCustomerController()
        {
            _context = new ApplicationDbContext();
        }
        
        IEnumerable<CustomerDto> IAPICustomerRepository.GetCustomers(string query)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return customerDtos;
        }

        CustomerDto IAPICustomerRepository.GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

               if (customer == null)
                   return null;

              return Mapper.Map<Customer, CustomerDto>(customer);
        }

        int IAPICustomerRepository.CreateCustomer(CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                return 0;

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto.Id;

        }

        CustomerDto IAPICustomerRepository.UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return null;

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return null;

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Mapper.Map<Customer,CustomerDto >(customerInDb);
        }

        bool? IAPICustomerRepository.DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return false;

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return true;
        }
    }
}