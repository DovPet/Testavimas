using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vidly.Controllers.Api;
using Vidly.Models;

namespace UnitTestProject2.Controllers.Api
{
    [TestClass]
    public class CustomersControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IAPICustomerRepository> mockAPICustomerRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAPICustomerRepository = this.mockRepository.Create<IAPICustomerRepository>();
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
                this.mockAPICustomerRepository.Object);
        }
    }
}
