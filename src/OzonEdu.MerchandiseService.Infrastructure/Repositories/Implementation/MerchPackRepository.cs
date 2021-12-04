using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class MerchPackRepository : IMerchPackRepository
    {
        private const int Timeout = 5;
        private readonly IChangeTracker _changeTracker;
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IEmailingServiceRepository _emailingServiceRepository;
        private readonly IEmployeeServiceRepository _employeeServiceRepository;

        public IUnitOfWork UnitOfWork { get; }
        public async Task<MerchPack> CreateAsync(MerchPack itemToCreate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                INSERT INTO MerchPack (name, employee_event_id, is_conference, merch_tem_skus)
                VALUES (@Name, @EmployeeEventId, @IsConference, @MerchItemSkus);";

            var parameters = new
            {
                Name = itemToCreate.Name,
                EmployeeEventId = itemToCreate.EmployeeEventId,
                IsConference = itemToCreate.IsConference,
                MerchItemSkus = itemToCreate.SkusRequested,
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToCreate);
            return itemToCreate;
        }

        public async Task<MerchPack> UpdateAsync(MerchPack itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                UPDATE Employee 
                SET name = @Name, 
                    employee_event_id = @EmployeeEventId, 
                    is_conference = @IsConference,
                    merch_item_skus = @MerchItemSkus
                WHERE id = @Id;";

            var parameters = new
            {
                Id = itemToUpdate.Id,
                Name = itemToUpdate.Name,
                EmployeeEventId = itemToUpdate.EmployeeEventId,
                IsConference = itemToUpdate.IsConference,
                MerchItemSkus = itemToUpdate.SkusRequested,
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToUpdate);
            return itemToUpdate;
        }
    }
}