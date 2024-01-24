using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericOData.UnitTests
{
    public class GenericODataIntegrationTests
    {
        private HttpClient _httpClient;
        private WebApplicationFactory<Program> _application;

        public GenericODataIntegrationTests()
        {
            _application = new WebApplicationFactory<Program>();
            _httpClient = _application.CreateClient();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
