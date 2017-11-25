using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vidly.App_Start;

namespace UnitTestProject2.App_Start
{
    [TestClass]
    public class MappingProfileTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            MappingProfile mappingProfile = this.CreateMappingProfile();

          
            // Assert

        }

        private MappingProfile CreateMappingProfile()
        {
            return new MappingProfile();
        }
    }
}
