using System;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class UnitTest1:BaseTest
    {
        [Fact]
        public async Task Test1()
        {
            var response = await this.testClient.GetAsync("http://localhost:64434/api/product");
        }
    }
}
