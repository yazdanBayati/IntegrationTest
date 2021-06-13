using IntergrationTest;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Test
{
    public class BaseTest
    {

        protected HttpClient testClient;
        
        protected BaseTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            this.testClient = appFactory.CreateClient();
        }
    }
}
