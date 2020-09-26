using Cashrewards.Application.Interfaces;
using Cashrewards.Dto;
using FluentResults;
using Moq;
using System;
using System.Collections.Generic;

namespace Cashrewards.Funtional.Test.Mock.MerchantsController
{
    public class MerchantsControllerMock
    {
        public static IEnumerable<MerchantDto> MockMerchantDtos = new MerchantDto[]
        {
            new MerchantDto
            {
                Id = 1,
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
                IsActive = true,
                Currency = "AUD",
                WebsiteUrl = "www.test-01.com",
                Country = "Australia",
                DiscountPercentage = 10.0m,
                CreatedTime = new DateTime(2000, 1, 1),
                UpdatedTime = new DateTime(2020, 1, 1)
            },
            new MerchantDto
            {
                Id = 2,
                UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896821",
                IsActive = false,
                Currency = "USD",
                WebsiteUrl = "www.test-02.com",
                Country = "America",
                DiscountPercentage = 0.0m,
                CreatedTime = new DateTime(2020, 12, 12),
            }
        };

        public static MerchantDto MockMerchantDto = new MerchantDto
        {
            Id = 1,
            UniqueId = "62178593-efbc-4ba2-9bbd-d2841c896820",
            IsActive = true,
            Currency = "AUD",
            WebsiteUrl = "www.test-01.com",
            Country = "Australia",
            DiscountPercentage = 10.0m,
            CreatedTime = new DateTime(2000, 1, 1),
            UpdatedTime = new DateTime(2020, 1, 1)
        };

        public static void Mock(Mock<IMerchantRepository> mockMerchantRepository)
        {
            mockMerchantRepository
                .Setup(m => m.GetMerchants())
                .ReturnsAsync(Result.Ok(MockMerchantDtos));

            mockMerchantRepository
                .Setup(m => m.GetMerchant(It.IsAny<string>()))
                .ReturnsAsync(Result.Ok(MockMerchantDto));

            mockMerchantRepository
                .Setup(m => m.CreateMerchant(It.IsAny<MerchantDto>()))
                .ReturnsAsync(Result.Ok());

            mockMerchantRepository
                .Setup(m => m.UpdateMerchant(It.IsAny<MerchantDto>()))
                .ReturnsAsync(Result.Ok());

            mockMerchantRepository
                .Setup(m => m.DeleteMerchant(It.IsAny<string>()))
                .ReturnsAsync(Result.Ok());
        }
    }
}
