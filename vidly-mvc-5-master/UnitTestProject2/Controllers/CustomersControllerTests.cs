using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vidly.Controllers;
using Vidly.Models;

namespace UnitTestProject2.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ICustomerRepository> mockCustomerRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCustomerRepository = this.mockRepository.Create<ICustomerRepository>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange


            // Act
            CustomersController customersController = this.CreateCustomersController();


            // Assert

        }

        private CustomersController CreateCustomersController()
        {
            return new CustomersController(
                this.mockCustomerRepository.Object);
        }
    }
}
