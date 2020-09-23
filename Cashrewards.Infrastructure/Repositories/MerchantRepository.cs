using Cashrewards.Application.Interfaces;
using Cashrewards.Dto;
using Dapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
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
                    *
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
                _logger.LogError($"Error on executing {nameof(GetMerchant)}");
                return Result.Fail<IEnumerable<MerchantDto>>(exception.Message);
            }
        }

        public Task<Result<MerchantDto>> GetMerchant(string uniqueId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> CreateMerchant(MerchantDto merchantDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateMerchant(MerchantDto merchantDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteMerchant(string uniqueId)
        {
            throw new NotImplementedException();
        }
    }
}
