using IntergrationTest;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApplication1.Product
{
    public class Test1: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public Test1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Product")]
        //[InlineData("/Index")]
        //[InlineData("/About")]
        //[InlineData("/Privacy")]
        //[InlineData("/Contact")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var file = new File();
            file.Name = "test";
            file.Path = "test";

            var json = JsonConvert.SerializeObject(file);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var postResponse = await client.PostAsync("http://localhost:64434/api/product", data);


            // Act
            var response = await client.GetAsync("http://localhost:64434/api/product");

            var result = response.Content.ReadAsStringAsync().Result;
            var arr = JsonConvert.DeserializeObject<List<string>>(result);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

        }
    }
}
