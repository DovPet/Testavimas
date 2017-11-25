using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidly.Models;
using Moq;
using Vidly.Controllers;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace UnitTestProject2
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void Index_Returns_CustomerList()
        {
            //Arange
            DateTime dd = new DateTime(1995, 06, 10);
            DateTime dd2 = new DateTime(1996, 06, 10);
            DateTime dd3 = new DateTime(1997, 06, 10);

            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();

            mock.Setup(m => m.Customers).Returns(new Customer[]
            {
                new Customer {Id = 4, Name="Jonas", IsSubscribedToNewsletter=false,MembershipTypeId=2,Birthdate=dd },
                new Customer {Id = 5, Name="Petras", IsSubscribedToNewsletter=true,MembershipTypeId=1,Birthdate=dd2 },
                new Customer {Id = 6, Name="Antanas", IsSubscribedToNewsletter=false,MembershipTypeId=3,Birthdate=dd3 }

            }.AsQueryable());

            CustomersController controller = new CustomersController(mock.Object);
            //Act
           
            var actual = (List<Customer>)controller.Index().Model;

            //Assert
            Assert.IsInstanceOfType(actual,typeof(List<Customer>));
        }

        [TestMethod]
        public void Details_Returns_DBCustomer()
        {
            //Arange
            DateTime dd = new DateTime(1995, 06, 10);
            DateTime dd2 = new DateTime(1996, 06, 10);
            DateTime dd3 = new DateTime(1997, 06, 10);
            var cust = new Customer
            {
                Id = 1,
                Name = "Jonas",
                IsSubscribedToNewsletter = false,
                MembershipTypeId = 2,
                Birthdate = dd
            };
            Mock <ICustomerRepository> mock = new Mock<ICustomerRepository>();

            mock.Setup(m => m.Customers).Returns(new Customer[]
              {
                new Customer {Id = 1, Name="Jonas", IsSubscribedToNewsletter=false,MembershipTypeId=2,Birthdate=dd },
                new Customer {Id = 2, Name="Petras", IsSubscribedToNewsletter=true,MembershipTypeId=1,Birthdate=dd2 },
                new Customer {Id = 3, Name="Antanas", IsSubscribedToNewsletter=false,MembershipTypeId=3,Birthdate=dd3 }

              }.AsQueryable());


            CustomersController controller = new CustomersController(mock.Object);
            //Act

            var actual = (Customer)controller.Details(1).Model;

            string expectedStr = cust.Id +" "+cust.Name+" "+cust.IsSubscribedToNewsletter+" "+cust.MembershipTypeId+" "+cust.Birthdate;
            string actualStr = actual.Id + " " + actual.Name + " " + actual.IsSubscribedToNewsletter + " " + actual.MembershipTypeId + " " + actual.Birthdate;
            //Assert
            Console.WriteLine("Cust "+expectedStr);
            Console.WriteLine("Act "+ actualStr);
            Assert.AreEqual(expectedStr, actualStr);
            
        }       

        [TestMethod]
        public void Updating_Customer()
        {
            //Arange
            DateTime dd = new DateTime(1995, 06, 10);
            DateTime dd2 = new DateTime(1996, 06, 10);
            DateTime dd3 = new DateTime(1997, 06, 10);

            var cust = new Customer {Id = 4, Name = null, IsSubscribedToNewsletter = false, MembershipTypeId = 10, Birthdate = dd};
            var cust2 = new Customer {Id = 3, Name = "JonasKitas", IsSubscribedToNewsletter = true, MembershipTypeId = 4, Birthdate = dd2 };

            Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();

            mock.Setup(m => m.Customers).Returns(new Customer[]
            {
                new Customer {Id = 4, Name="Jonas", IsSubscribedToNewsletter=false,MembershipTypeId=2,Birthdate=dd },
                new Customer {Id = 5, Name="Petras", IsSubscribedToNewsletter=true,MembershipTypeId=1,Birthdate=dd2 },
                new Customer {Id = 6, Name="Antanas", IsSubscribedToNewsletter=false,MembershipTypeId=3,Birthdate=dd3 }

            }.AsQueryable());

            CustomersController controller = new CustomersController(mock.Object);
            //Act

            controller.Save(cust);
            var actual = (Customer)controller.Details(4).Model;
            string expectedStr = cust.Id + " " + cust.Name + " " + cust.IsSubscribedToNewsletter + " " + cust.MembershipTypeId + " " + cust.Birthdate;
            string actualStr = actual.Id + " " + actual.Name + " " + actual.IsSubscribedToNewsletter + " " + actual.MembershipTypeId + " " + actual.Birthdate;
           
            //Assert
            Console.WriteLine("Cust " + expectedStr);
            Console.WriteLine("Act " + actualStr);
            Assert.AreEqual(expectedStr, actualStr);
  
        }
        //[TestMethod]
        //public void Adding_Customer()
        //{
        //    //Arange
        //    DateTime dd = new DateTime(1995, 06, 10);
        //    DateTime dd2 = new DateTime(1996, 06, 10);
        //    DateTime dd3 = new DateTime(1997, 06, 10);

        //    var cust = new Customer { Id = 0, Name = "Kazys", IsSubscribedToNewsletter = false, MembershipTypeId = 3, Birthdate = dd };
        //    var cust2 = new Customer { Id = 3, Name = "JonasKitas", IsSubscribedToNewsletter = true, MembershipTypeId = 4, Birthdate = dd2 };

        //    Mock<ICustomerRepository> mock = new Mock<ICustomerRepository>();

        //    mock.Setup(m => m.Customers).Returns(new Customer[]
        //    {
        //        new Customer {Id = 4, Name="Jonas", IsSubscribedToNewsletter=false,MembershipTypeId=2,Birthdate=dd },
        //        new Customer {Id = 5, Name="Petras", IsSubscribedToNewsletter=true,MembershipTypeId=1,Birthdate=dd2 },
        //        new Customer {Id = 6, Name="Antanas", IsSubscribedToNewsletter=false,MembershipTypeId=3,Birthdate=dd3 }

        //    }.AsQueryable());

            
        //    CustomersController controller = new CustomersController(mock.Object);
        //    //Act
        //    var stubMockSet = new Mock<DbSet<Customer>>(cust2);
        //    var stubMockdbcontex = new Mock<ApplicationDbContext>();
        //    //stubMockSet.Verify(m => m.Add(It.IsAny<Customer>()),Times.Once());
        //    stubMockdbcontex.Setup(m => m.Set<Customer>()).Returns(stubMockSet.Object);

        //   CustomersController controllers = new CustomersController(stubMockdbcontex.Object);
        //    //stubMockSet.Verify(x => x.Add(It.IsAny<Customer>()),Times.Once());
        //    //controllers.Save(cust);

        //      var actual = (Customer)controller.Details(0).Model;
        //    string expectedStr = cust.Id + " " + cust.Name + " " + cust.IsSubscribedToNewsletter + " " + cust.MembershipTypeId + " " + cust.Birthdate;
        //    string actualStr = actual.Id + " " + actual.Name + " " + actual.IsSubscribedToNewsletter + " " + actual.MembershipTypeId + " " + actual.Birthdate;

        //    //Assert
        //    Console.WriteLine("Cust " + expectedStr);
        //    Console.WriteLine("Act " + actualStr);
        //    Assert.AreEqual(expectedStr, actualStr);

        //}
    }
}
