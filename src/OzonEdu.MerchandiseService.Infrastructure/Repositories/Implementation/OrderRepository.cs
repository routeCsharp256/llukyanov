using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore.UnitOfWork;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using IUnitOfWork = OzonEdu.MerchandiseService.Domain.Contracts.IUnitOfWork;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private const int Timeout = 5;
        private readonly IChangeTracker _changeTracker;
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IQueryExecutor _queryExecutor;

        public OrderRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IQueryExecutor queryExecutor)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _queryExecutor = queryExecutor;
        }

        public IUnitOfWork UnitOfWork { get; }

        public async Task<Order> CreateAsync(Order itemToCreate, CancellationToken cancellationToken = default)
        {
            // TODO: селектить deadline из базы
            const string query = @"
                INSERT INTO Order (employee_email, 
                    ,skus_requested 
                    ,skus_reserved 
                    ,merch_pack_id 
                    ,status
                    ,priority
                    ,created_at 
                    ,closed_at 
                    ,manager_id 
                    ,deadline
                    ,is_employee_received_order)
                VALUES (@EmployeeEmail
                    ,@SkusRequested
                    ,null
                    ,@MerchPackId
                    ,@Status
                    ,@Priority
                    ,@CreatedAt
                    ,null
                    ,null
                    ,@Deadline
                    ,false);";

            var parameters = new
            {
                itemToCreate.EmployeeEmail,
                itemToCreate.SkusRequested,
                itemToCreate.MerchPackId,
                Status = OrderStatus.New,
                Priority = itemToCreate.Priority ?? OrderPriority.Medium,
                itemToCreate.Deadline,
                CreatedAt = DateTime.Now.Date
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

        // TODO: тут не только менеджер обновляется
        public async Task<Order> UpdateAsync(Order itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                UPDATE Order 
                SET manager_id = @ManagerId
                    ,skus_reserved = @SkusReserved
                    ,closed_at = @ClosedAt
                    ,is_employee_received_order = @IsEmployeeReceivedOrder
                WHERE id = @OrderId;";

            var parameters = new
            {
                OrderId = itemToUpdate.Id, itemToUpdate.ManagerId
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

        public async Task<Order> GetOrderByIdAsync(long OrderId, CancellationToken cancellationToken = default)
        {
            const string query = @"
                SELECT id
                    ,employee_id
                    ,skus_requested
                    ,skus_reserved
                    ,merch_pack_id
                    ,status
                    ,priority
                    ,created_at
                    ,closed_at
                    ,deadline
                    ,manager_id
                    ,is_employee_received_order
                FROM Order
                WHERE id = @OrderId;";

            var parameters = new
            {
                OrderId
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var result = await connection.QuerySingleOrDefaultAsync(commandDefinition);

            return result;
        }

        public async Task<IEnumerable<Order>> GetOrdersByEmployeeIdAsync(int employeeId,
            CancellationToken cancellationToken = default)
        {
            const string query = @"
                SELECT id
                    ,employee_id
                    ,skus_requested
                    ,skus_reserved
                    ,merch_pack_id
                    ,status
                    ,priority
                    ,created_at
                    ,closed_at
                    ,deadline
                    ,manager_id
                    ,is_employee_received_order
                FROM Order
                WHERE emloyee_id = @EmployeeId;";

            var parameters = new
            {
                EmployeeId = employeeId
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var result = await connection.QueryAsync<Order>(commandDefinition);

            return result;
        }

        public async Task TryReserveMerchItemsAsync(CancellationToken cancellationToken = default)
        {
            // Метод вызывается тогда, когда на склад поступают новые товары (по идее, поступление товаров должно в Кафку писаться)

            // 1. Получаем доступные товары с помощью метода GetAvailableQuantity() из StockItemRepository
            // 2. Получаем все доступные заказов, отсортированные по возрастанию дедлайна и убыванию приоритета
            // 2. Распределяем (добавляем в SkuReserved) товары среди заказов
            // 3. Убираем со склада зарезервированные итемы командой GiveOutStockItems() из StockItemRepository
            // 4. Для всех заказов: если заказ завершён, меняем его статус с Active на Prepared
            // 5. Делаем UpdateAsync заказов

            throw new NotImplementedException();
        }

        public Task CompleteOrder(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}