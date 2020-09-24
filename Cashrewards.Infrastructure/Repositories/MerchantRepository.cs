using Cashrewards.Application.Interfaces;
using Cashrewards.Dto;
using Dapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cashrewards.Infrastructure.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<MerchantRepository> _logger;

        public MerchantRepository(IDbConnection dbConnection, ILogger<MerchantRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<MerchantDto>>> GetMerchants()
        {
            const string sql = @"
                SELECT
                    [Id],
                    [UniqueId],
                    [IsActive],
                    [Currency],
                    [WebsiteUrl],
                    [Country],
                    [DiscountPercentage],
                    [CreatedTime],
                    [UpdatedTime]
                FROM [dbo].[Merchant]
            ";

            try
            {
                var result = await _dbConnection.QueryAsync<MerchantDto>(
                    sql,
                    commandType: CommandType.Text);

                return Result.Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error on executing {nameof(GetMerchants)}");
                return Result.Fail<IEnumerable<MerchantDto>>(exception.Message);
            }
        }

        public async Task<Result<MerchantDto>> GetMerchant(string uniqueId)
        {
            const string sql = @"
                SELECT
                    [Id],
                    [UniqueId],
                    [IsActive],
                    [Currency],
                    [WebsiteUrl],
                    [Country],
                    [DiscountPercentage],
                    [CreatedTime],
                    [UpdatedTime]
                FROM [dbo].[Merchant]
                WHERE 
                    UniqueId = @UniqueId
            ";

            var parameters = new
            {
                UniqueId = uniqueId
            };

            try
            {
                var resultCollection = await _dbConnection.QueryAsync<MerchantDto>(
                    sql,
                    parameters,
                    commandType: CommandType.Text);

                return Result.Ok(resultCollection.SingleOrDefault());
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error on executing {nameof(GetMerchants)}");
                return Result.Fail<MerchantDto>(exception.Message);
            }
        }

        public async Task<Result> CreateMerchant(MerchantDto merchantDto)
        {
            const string sql = @"
                INSERT INTO [dbo].[Merchant]
                VALUES (
                    @UniqueId,
                    @IsActive,
                    @Currency,
                    @WebsiteUrl,
                    @Country,
                    @DiscountPercentage,
                    @CreatedTime,
                    @UpdatedTime
                )
            ";

            var parameters = new
            {
                merchantDto.UniqueId,
                merchantDto.IsActive,
                merchantDto.Currency,
                merchantDto.WebsiteUrl,
                merchantDto.Country,
                merchantDto.DiscountPercentage,
                CreatedTime = DateTime.Now,
                UpdatedTime = (DateTime?)null
            };

            try
            {
                await _dbConnection.ExecuteAsync(
                    sql,
                    parameters,
                    commandType: CommandType.Text);

                return Result.Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error on executing {nameof(CreateMerchant)}");
                return Result.Fail(exception.Message);
            }
        }

        public async Task<Result> UpdateMerchant(MerchantDto merchantDto)
        {
            const string sql = @"
                UPDATE [dbo].[Merchant]
                SET
                    IsActive = @IsActive,
                    Currency = @Currency,
                    WebsiteUrl = @WebsiteUrl,
                    Country = @Country,
                    DiscountPercentage = @DiscountPercentage,
                    UpdatedTime = @UpdatedTime
                WHERE
                    UniqueId = @UniqueId
            ";

            var parameters = new
            {
                merchantDto.UniqueId,
                merchantDto.IsActive,
                merchantDto.Currency,
                merchantDto.WebsiteUrl,
                merchantDto.Country,
                merchantDto.DiscountPercentage,
                UpdatedTime = DateTime.Now
            };

            try
            {
                await _dbConnection.ExecuteAsync(
                    sql,
                    parameters,
                    commandType: CommandType.Text);

                return Result.Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error on executing {nameof(UpdateMerchant)}");
                return Result.Fail(exception.Message);
            }
        }

        public async Task<Result> DeleteMerchant(string uniqueId)
        {
            const string sql = @"
                DELETE FROM [dbo].[Merchant]
                WHERE 
                    UniqueId = @UniqueId
            ";

            var parameters = new
            {
                UniqueId = uniqueId,
            };

            try
            {
                await _dbConnection.ExecuteAsync(
                    sql,
                    parameters,
                    commandType: CommandType.Text);

                return Result.Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error on executing {nameof(DeleteMerchant)}");
                return Result.Fail(exception.Message);
            }
        }
    }
}
