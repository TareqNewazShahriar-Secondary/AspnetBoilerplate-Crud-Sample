using System.Threading.Tasks;
using Testing.Models.TokenAuth;
using Testing.Web.Controllers;
using Shouldly;
using Xunit;

namespace Testing.Web.Tests.Controllers
{
    public class HomeController_Tests: TestingWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}