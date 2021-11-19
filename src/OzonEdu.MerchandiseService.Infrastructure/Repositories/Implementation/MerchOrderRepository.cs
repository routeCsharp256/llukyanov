using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchOrderRepository : IMerchOrderRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;
        
        public IUnitOfWork UnitOfWork { get; }

        public async Task<MerchOrder> CreateAsync(MerchOrder itemToCreate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                INSERT INTO MerchOrder (employee_id, skus_requested, skus_reserved, 
                                        merch_pack_id, status, priority, created_at, 
                                        closed_at, manager_id, deadline, is_employee_received_order)
                VALUES (@EmployeeId, @SkusRequested, null, @MerchPackId, @Status, 
                        @Priority, @CreatedAt, null, null, false);";

            var parameters = new
            {
                EmployeeId = itemToCreate.EmployeeId,
                SkusRequested = itemToCreate.SkusRequested,
                SkusReserved = itemToCreate.SkusRequested,
                MerchPackId = itemToCreate.MerchPack.Id,
                Status = itemToCreate.Status,
                Priority = itemToCreate.Priority.Id,
                CreatedAt = DateTime.Now,
                ClosedAt = itemToCreate.ClosedAt,
                ManagerId = itemToCreate.ManagerId,
                IsEmployeeReceivedOrder = itemToCreate.IsEmployeeReceivedOrder,
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToCreate);
            return itemToCreate;
        }

        public Task<MerchOrder> UpdateAsync(MerchOrder itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sku>> CheckMerchItemsAsync(List<Sku> skus, CancellationToken cancellationToken = default)
        {
            // 1. вызываем метод /api/stocks/quantity
            // 2. приводим полученный результат к списку SKU
            // 3. возвращаем список SKU
            throw new NotImplementedException();
        }

        public Task CompleteMerchOrder(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}