using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidly.Controllers.Api;
using Vidly.Models;
using System.Web.Http.Results;
using Moq;
using System.Linq;
using System.Data.Entity;
using Vidly.Dtos;
using System.Net;
using System.Web.Http.Results;


namespace UnitTestProject2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class APITests
    {
        public APITests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

            [TestMethod]
            public void API_GetCustomers_OK()
            {
                //Arrange
            var fakeCustomers = new List<CustomerDto>{
            new CustomerDto{ Id = 1, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 1,Name="Jonas"  },
            new CustomerDto{ Id = 21, Birthdate=DateTime.Now, IsSubscribedToNewsletter=true, MembershipTypeId = 2,Name="Antanas"  },
            new CustomerDto{ Id = 3, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 3,Name="Pentas"  }
            

                };
                var repository = new Mock<IAPICustomerRepository>();
                repository
                    .Setup(_ => _.GetCustomers(It.IsAny<string>()))
                    .Returns(fakeCustomers)
                    .Verifiable();

                var controller = new CustomersController(repository.Object);
            OkResult ok = new OkResult(controller);
            //Act
            var result = controller.GetCustomers();

            //Assert
            Console.WriteLine("Cust " + result);
            repository.Verify();
            Assert.ReferenceEquals(ok, result);
            //..other assertions
        }

            //...Other tests
       
    
    
[TestMethod]
public void API_GetCustomer_By_Id_OK()
{
    //Arrange
    var fakeCustomers = new List<CustomerDto>{
            new CustomerDto{ Id = 1, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 1,Name="Jonas"  },
            new CustomerDto{ Id = 2, Birthdate=DateTime.Now, IsSubscribedToNewsletter=true, MembershipTypeId = 2,Name="Antanas"  },
            new CustomerDto{ Id = 3, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 3,Name="Pentas"  }


                };
    var repository = new Mock<IAPICustomerRepository>();
    repository
        .Setup(_ => _.GetCustomer(1))
        .Returns(fakeCustomers[1])
        .Verifiable();

    var controller = new CustomersController(repository.Object);
            OkResult ok = new OkResult(controller);

    //Act
    var result = controller.GetCustomer(1);

    //Assert
    Console.WriteLine("Cust " + result);
    repository.Verify();
   Assert.ReferenceEquals(ok, result);

            //..other assertions
        }
        [TestMethod]
        public void API_GetCustomer_By_Id_NOT_OK()
        {
           
            //Arrange

            var fakeCustomers = new List<CustomerDto>{
            new CustomerDto{ Id = 1, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 1,Name="Jonas"  },
            new CustomerDto{ Id = 2, Birthdate=DateTime.Now, IsSubscribedToNewsletter=true, MembershipTypeId = 2,Name="Antanas"  },
            new CustomerDto{ Id = 3, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 3,Name="Pentas"  }

            
                };
            var repository = new Mock<IAPICustomerRepository>();
            repository
                .Setup(_ => _.GetCustomer(2))
                .Returns(fakeCustomers[2])
                .Verifiable();

            var controller = new CustomersController(repository.Object);
            NotFoundResult NFR = new NotFoundResult(controller);
            //Act
            var result = controller.GetCustomer(1);

            //Assert
                    
            Console.WriteLine("repo " + repository);
            Console.WriteLine("result " + result);
            Console.WriteLine("nfr " + NFR);

            Assert.ReferenceEquals(NFR, result);
            //..other assertions
        }

        
        [TestMethod]
        public void API_UpdateCustomer_OK()
        {

            //Arrange

            var fakeCustomers = new List<CustomerDto>{
            new CustomerDto{ Id = 1, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 1,Name="Jonas"  },
            new CustomerDto{ Id = 2, Birthdate=DateTime.Now, IsSubscribedToNewsletter=true, MembershipTypeId = 2,Name="Antanas"  },
            new CustomerDto{ Id = 3, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 3,Name="Pentas"  },
            new CustomerDto{ Id = 1, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 3,Name="Pentas"  }


                };
            var repository = new Mock<IAPICustomerRepository>();
            repository
                .Setup(_ => _.UpdateCustomer(1,It.IsAny<CustomerDto>()))
                .Returns(fakeCustomers[1])
                .Verifiable();

            var controller = new CustomersController(repository.Object);
            OkResult ok = new OkResult(controller);
            //Act
            var result = controller.UpdateCustomer(1,fakeCustomers[3]);

            //Assert

            Console.WriteLine("repo " + repository);
            Console.WriteLine("result " + result);


            Assert.ReferenceEquals(ok, result);
            //..other assertions
        }
        [TestMethod]
        public void API_DeleteCustomer_OK()
        {

            //Arrange

            var fakeCustomers = new List<CustomerDto>{
            new CustomerDto{ Id = 1, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 1,Name="Jonas"  },
            new CustomerDto{ Id = 2, Birthdate=DateTime.Now, IsSubscribedToNewsletter=true, MembershipTypeId = 2,Name="Antanas"  },
            new CustomerDto{ Id = 3, Birthdate=DateTime.Now, IsSubscribedToNewsletter=false, MembershipTypeId = 3,Name="Pentas"  }


                };
            var repository = new Mock<IAPICustomerRepository>();
            repository
                .Setup(_ => _.DeleteCustomer(2))
                .Returns(true)
                .Verifiable();

            var controller = new CustomersController(repository.Object);
            OkResult ok = new OkResult(controller);
            //Act
            var result = controller.DeleteCustomer(fakeCustomers[1].Id);

            //Assert

            Console.WriteLine("repo " + repository);
            Console.WriteLine("result " + result);


            Assert.ReferenceEquals(ok, result);
            //..other assertions
        }
    }
    
}


  