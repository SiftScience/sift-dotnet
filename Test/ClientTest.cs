using Sift;
using Xunit;
using System.Net.Http;

namespace Test
{
    public class ClientTest
    {
        [Fact]
        public void TestFailsToCreateClientWithAPIKeyNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Client(null)
            );
            Assert.Throws<ArgumentNullException>(
                () => new Client(null, new HttpClient())
            );
        }

        [Fact]
        public void TestFailsToCreateClientWithEmptyAPIKey()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Client("")
            );
            Assert.Throws<ArgumentNullException>(
                () => new Client("", new HttpClient())
            );
        }
    }

}
