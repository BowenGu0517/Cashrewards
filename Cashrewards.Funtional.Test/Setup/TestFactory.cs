using Cashrewards.Application.Interfaces;
using Cashrewards.Funtional.Test.Mock.MerchantsController;
using Cashrewards.Host;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Cashrewards.Funtional.Test.Setup
{
    public class TestFactory : WebApplicationFactory<Startup>
    {
        public Mock<IMerchantRepository> MockMerchantRepository = new Mock<IMerchantRepository>();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            MerchantsControllerMock.Mock(MockMerchantRepository);

            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(s => MockMerchantRepository.Object);
            });
        }
    }
}
