using GiftExchange.Library;
using NUnit.Framework;

namespace GiftExchange.Tests
{
    [TestFixture]
    public class AwsSmsSenderTests
    {
        [Test]
        public void Send_test()
        {
            // Arrange
            var service = new AwsSMSSender();

            // Act
            service.Send("+19995554444", "I haz test");

            // Assert

        }
    }
}
