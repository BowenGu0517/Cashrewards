using Cashrewards.Application.Commands.CreateMerchant;
using Cashrewards.Application.Commands.UpdateMerchant;
using Cashrewards.Funtional.Test.Mock;
using Cashrewards.Funtional.Test.Setup;
using Cashrewards.ViewModel;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Cashrewards.Funtional.Test
{
    public class MerchantsControllerTests : IClassFixture<TestFactory>
    {
        private readonly string URL = "api/merchants";
        private readonly TestFactory _testFactory;

        public MerchantsControllerTests(TestFactory testFactory)
        {
            _testFactory = testFactory;
        }

        [Fact]
        public async void ShouldGetMerchantsCorrectly()
        {
            var requestMessage = MockHelper.CreateHttpRequestMessage(
                URL,
                HttpMethod.Get);

            var response = await _testFactory.CreateClient().SendAsync(requestMessage);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseBodyJson = await response.Content.ReadAsStringAsync();
            var responseBody = JsonConvert.DeserializeObject<IEnumerable<MerchantViewModel>>(responseBodyJson);

            responseBody.Should().NotBeEmpty();
            responseBody.Count().Should().Be(2);

            var merchantViewModels = responseBody.ToList();
            merchantViewModels[0].UniqueId.Should().Be("62178593-efbc-4ba2-9bbd-d2841c896820");
            merchantViewModels[0].WebsiteUrl.Should().Be("www.test-01.com");
            merchantViewModels[1].UniqueId.Should().Be("62178593-efbc-4ba2-9bbd-d2841c896821");
            merchantViewModels[1].WebsiteUrl.Should().Be("www.test-02.com");
        }

        [Theory]
        [InlineData("62178593-efbc-4ba2-9bbd-d2841c896820")]
        public async void ShouldGetMerchantCorrectly(string uniqueId)
        {
            var requestMessage = MockHelper.CreateHttpRequestMessage(
                $"{URL}/{uniqueId}",
                HttpMethod.Get);

            var response = await _testFactory.CreateClient().SendAsync(requestMessage);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseBodyJson = await response.Content.ReadAsStringAsync();
            var responseBody = JsonConvert.DeserializeObject<MerchantViewModel>(responseBodyJson);

            responseBody.Should().NotBeNull();

            responseBody.UniqueId.Should().Be(uniqueId);
        }

        [Fact]
        public async void ShouldGreateMerchantCorrectly()
        {
            var requestBody = new CreateMerchantCommand
            {
                IsActive = true,
                Currency = "AUD",
                WebsiteUrl = "www.test-03.com",
                Country = "Australia",
                DiscountPercentage = 5.0m
            };

            var requestMessage = MockHelper.CreateHttpRequestMessage(
                URL,
                HttpMethod.Post,
                requestBody);

            var response = await _testFactory.CreateClient().SendAsync(requestMessage);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async void ShouldUpdateMerchantCorrectly()
        {
            var requestBody = new UpdateMerchantCommand
            {
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
                IsActive = true,
                Currency = "AUD",
                WebsiteUrl = "www.test-04.com",
                Country = "Australia",
                DiscountPercentage = 5.0m
            };

            var requestMessage = MockHelper.CreateHttpRequestMessage(
                URL,
                HttpMethod.Put,
                requestBody);

            var response = await _testFactory.CreateClient().SendAsync(requestMessage);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("62178593-efbc-4ba2-9bbd-d2841c896820")]
        public async void ShouldDeleteMerchantCorrectly(string uniqueId)
        {
            var requestMessage = MockHelper.CreateHttpRequestMessage(
                $"{URL}/{uniqueId}",
                HttpMethod.Delete);

            var response = await _testFactory.CreateClient().SendAsync(requestMessage);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
