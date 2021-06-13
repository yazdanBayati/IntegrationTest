using IntergrationTest;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebApplication1
{
    public class BaseTest: IClassFixture<WebApplicationFactory<FackeStartup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;

        protected BaseTest(WebApplicationFactory<Startup> factory)
        {
            this._factory = factory;
        }
    }
}
