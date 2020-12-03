using Edgias.Agrik.API.Models.Form;
using Edgias.Agrik.API.Models.View;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Edgias.Agrik.FunctionalTests.APIs.CropategoryEndPoints
{
    [Collection("Sequential")]
    public class CreateEndPoint : IClassFixture<ApiTestFixture>
    {
        JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        private string _testDescription = "test description";
        private string _testName = "test name";

        public CreateEndpoint(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsSuccessGivenValidNewItemAndAdminUserToken()
        {
            StringContent jsonContent = GetValidNewItemJson();

            HttpResponseMessage response = await Client.PostAsync("api/catalog-items", jsonContent);
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<CropCategoryApiModel>();

            Assert.Equal(_testDescription, model.CatalogItem.Description);
            Assert.Equal(_testName, model.CatalogItem.Name);
        }

        private StringContent GetValidNewItemJson()
        {
            CropCategoryFormApiModel request = new CropCategoryFormApiModel()
            {
                Description = _testDescription,
                Name = _testName
            };

            StringContent jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            return jsonContent;
        }
    }
}
