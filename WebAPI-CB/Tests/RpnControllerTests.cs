using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_CB.Controllers;

namespace WebAPI_CB.Tests
{
    [TestClass]
    public class RpnControllerTests
    {
        [TestMethod]
        public void GetOperands_ShouldReturnAllOperands()
        {
            // Assign
            var rpnController = new RpnController();

            // Act
            var result = rpnController.GetOperands();

            // Assert
            result.Should().HaveCount(4);
        }
    }
}
