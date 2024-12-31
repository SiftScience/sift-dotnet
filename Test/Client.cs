using Sift;
using Sift.Core;
using System.Text;
using Xunit;

namespace Test
{
    public class Client
    {
        [Fact]
        public void TestCreateClientWithAPIKeyNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => new Client(null)
            );

        }
    }

}
