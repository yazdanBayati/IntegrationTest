using DevExpress.Data.Browsing;
using IntergrationTest;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class BasicTests
    : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        protected readonly HttpClient TestClient;

        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            var appFactory = new WebApplicationFactory<Startup>()
               .WithWebHostBuilder(builder =>
               {
                   builder.ConfigureServices(services =>
                   {
                       //services.RemoveAll(typeof(DataContext));
                       //services.AddDbContext<DataContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                   });
               });

            TestClient = appFactory.CreateClient();
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
            //var client = _factory.CreateClient();

            // Act
            var response = await this.TestClient.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());

        }
    }
}
