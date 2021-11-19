using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;
        
        private readonly IEmployeeServiceRepository _employeeServiceRepository;
        private readonly IEmailingServiceRepository _emailingServiceRepository;

        public IUnitOfWork UnitOfWork { get; }

        public async Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                INSERT INTO Employee (id, full_name, department, email)
                VALUES (@Id, @FullName, @Department, @Email);";

            var parameters = new
            {
                Id = itemToCreate.Id,
                FullName = $"{itemToCreate.FullName.LastName} {itemToCreate.FullName.FirstName}",
                Department = itemToCreate.Department.Value,
                Email = itemToCreate.Email.Value,
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

        public async Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string query = @"
                UPDATE Employee 
                SET full_name = @FullName, 
                    department = @Department, 
                    email = @Email,
                VALUES (@FullName, @Department, @Email);";

            var parameters = new
            {
                FullName = $"{itemToUpdate.FullName.LastName} {itemToUpdate.FullName.FirstName}",
                Department = itemToUpdate.Department.Value,
                Email = itemToUpdate.Email.Value,
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
            _changeTracker.Track(itemToUpdate);
            return itemToUpdate;
        }

        public async Task<bool> CheckIsEventMerchReceived(long employeeId, int employeeEventId, 
            CancellationToken cancellationToken = default)
        {
            var allConferences = await _employeeServiceRepository.GetAllConferences();
            
            // запрос, если эвент - НЕ конференция
            const string query = @"
                SELECT COUNT(1) 
                FROM MerchOrder o
                JOIN MerchPack p ON p.id = o.merch_pack_id
                WHERE employee_id = @EmployeeId
                    AND p.employee_event_id = @EmployeeEventId
                    AND p.is_conference = FALSE;";
            
            // TODO:
                // запрос, если эвент - конференция
                // заранее загружаем в БД мерч-сервиса список всех конференций и сотрудников
                // которые привязаны к конференциям
            // const string query2 = @"
            //     SELECT COUNT(1) 
            //     FROM MerchOrder o
            //     JOIN MerchPack p ON p.id = o.merch_pack_id
            //     LEFT JOIN EmployeeConference ec ON ec.employee_id = o.employee_id
            //     LEFT JOIN Conference c ON c.id = ec.conference_id
            //     WHERE employee_id = @EmployeeId
            //         AND p.employee_event_id = @EmployeeEventId
            //         AND p.is_conference = FALSE;";

            var parameters = new
            {
                EmployeeId = employeeId,
                EmployeeEventId = employeeEventId,
            };
            var commandDefinition = new CommandDefinition(
                query,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);

            var result = await connection.QuerySingleAsync<int>(commandDefinition);
            return result <= 0;
        }

        public async Task UpdateConferencesInfo(CancellationToken cancellationToken = default)
        {
            var allConferences = await _employeeServiceRepository.GetAllConferences();
            var query = @"
                TRUNCATE TABLE Conference;
 
                INSERT INTO Conference (id, name, date, description)
                VALUES
                (1, 'conf#1', '2020-01-02', 'this conference is passed'),
                (2, 'conf#22', '2022-01-02', 'that conference will be soon...');";
            
            var commandDefinition = new CommandDefinition(
                query,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            await connection.ExecuteAsync(commandDefinition);
        }

        public async Task NotifyEmployeeAboutMerch(long employeeId, CancellationToken cancellationToken = default)
        {
            const string getEmailquery = @"
                SELECT email
                FROM Employee 
                WHERE id = @EmployeeId;";
            var parameters = new
            {
                EmployeeId = employeeId,
            };
            var commandDefinition = new CommandDefinition(
                getEmailquery,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            
            var email = await connection.QuerySingleOrDefaultAsync(commandDefinition);
            var subject = "[MerchandiseService] Заберите ваши подарки!";
            var text = "Мерч по случаю <вставить_нужное> готов! Чтобы получить его, поднимитесь на этаж, прямо по коридуру, налево, направо, снова налево, спуститесь и поднимитесь.";
            
            _emailingServiceRepository.SendMailSingle(email, subject, text);
        }
    }
}