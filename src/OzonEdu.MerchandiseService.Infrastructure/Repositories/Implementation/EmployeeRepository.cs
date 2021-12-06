using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Models;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const int Timeout = 5;
        private readonly IChangeTracker _changeTracker;
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IEmployeeServiceRepository _employeeServiceRepository;

        public IUnitOfWork UnitOfWork { get; }

        public async Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                INSERT INTO Employee (id, full_name, department, email)
                VALUES (@Id, @FullName, @Department, @Email);";

            var parameters = new
            {
                itemToCreate.Id,
                FullName = $"{itemToCreate.FullName.LastName} {itemToCreate.FullName.FirstName}",
                Department = itemToCreate.Department.Value,
                Email = itemToCreate.Email.Value
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

        public async Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                UPDATE Employee 
                SET full_name = @FullName, 
                    department = @Department, 
                    email = @Email
                WHERE id = @EmployeeId;";

            var parameters = new
            {
                EmployeeId = itemToUpdate.Id,
                FullName = $"{itemToUpdate.FullName.LastName} {itemToUpdate.FullName.FirstName}",
                Department = itemToUpdate.Department.Value,
                Email = itemToUpdate.Email.Value
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

        // REMARK
        // здесь считаем, что из Кафки мы получаем и ID мерч-пака, и ID события для сотрудника (так описано в описании)
        // то есть нам остаётся только проверить, не выдавался ли уже такой мерч-пак
        public async Task<bool> CheckIsMerchPackReceivedAsync(string employeeEmail, int employeeEventId,
            int merchPackId, CancellationToken cancellationToken = default)
        {
            // TODO: добавить проверку дедлайна, если дедлайн прошёл И событие НЕ коференция, то считаем, что заказ не выполнен, и его можно создать заново, но отсылаем пометку, что заказ просрочен
            // : если дедлайн прошёл И событие конференция, то заказ просрочен, и новый заказ мы не выдаём
            const string query = @"
                SELECT EXISTS (
                    SELECT TRUE
                    FROM Order o
                    JOIN MerchPack mp ON mp.id = o.merch_pack_id
                    JOIN Employee e ON e.id = o.employee_id
                    WHERE e.email = @EmployeeEmail 
                        AND mp.employee_event_id = @EmployeeEventId
                        AND o.id = @MerchPackId
                );";

            var parameters = new
            {
                EmployeeEmail = employeeEmail,
                EmployeeEventId = employeeEventId,
                MerchPackId = merchPackId
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var result = await connection.QuerySingleAsync<bool>(commandDefinition);
            return result;
        }

        public async Task<OrderReadyMessage> CreateOrderReadyNotification(long orderId, CancellationToken cancellationToken = default)
        {
            const string query = @"
                SELECT o.id as order_id 
                    ,mp.name as merch_pack
                    ,e.first_name
                    ,e.email
                FROM Order o 
                JOIN Employee e ON e.id = o.employee_id
                LEFT JOIN MerchPack mp on mp.id = o.merch_pack_id
                WHERE o.id = @OrderId;";

            var parameters = new
            {
                OrderId = orderId
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var result = await connection.QuerySingleOrDefaultAsync<EmployeeNotificatoionDto>(commandDefinition);

            var emailContent = CreateOrderReadyEmail(result);
            return new OrderReadyMessage
            {
                Email = result.Email,
                Subject = emailContent.Subject,
                Text = emailContent.Text,
            };
        }

        private EmailContentDto CreateOrderReadyEmail(EmployeeNotificatoionDto notificatoion)
        {
            var emailContent = new EmailContentDto();
            emailContent.Subject = $"{notificatoion.FirstName}, ваш заказ #{notificatoion.OrderId} готов!";
            
            // REMARK: да, здесь будут лишние пробелы, если вот так представлять текст, но, думаю, это несущественно сейчас 
            if (notificatoion.MerchPack is not null)
            {
                emailContent.Text =
                    $@"Ваш набор мерча ""{notificatoion.MerchPack}"" готов!
                    Чтобы получить его, поднимитесь на этаж, прямо по коридуру, 
                    налево, направо, снова налево, спуститесь и поднимитесь.";
            }
            else
            {
                emailContent.Text =
                    $@"Ваш индивидуальный заказ мерча готов!
                    Чтобы получить его, поднимитесь на этаж, прямо по коридуру, 
                    налево, направо, снова налево, спуститесь и поднимитесь.";
            }

            return emailContent;
        } 
    } 
}