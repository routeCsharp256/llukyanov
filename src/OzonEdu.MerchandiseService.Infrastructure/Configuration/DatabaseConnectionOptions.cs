namespace OzonEdu.MerchandiseService.Infrastructure.Configuration
{
    public class DatabaseConnectionOptions
    {
        public DatabaseConnectionOptions(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}