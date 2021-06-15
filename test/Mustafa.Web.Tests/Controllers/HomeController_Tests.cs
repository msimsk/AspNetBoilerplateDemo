using System.Threading.Tasks;
using Mustafa.Models.TokenAuth;
using Mustafa.Web.Controllers;
using Shouldly;
using Xunit;

namespace Mustafa.Web.Tests.Controllers
{
    public class HomeController_Tests: MustafaWebTestBase
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