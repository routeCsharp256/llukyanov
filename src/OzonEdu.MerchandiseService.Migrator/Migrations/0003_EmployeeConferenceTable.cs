using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(3)]
    public class EmployeeConference : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists Conference(
                    employee_id INT NOT NULL,
                    conference_id INT NOT NULL;"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists Conference;");
        }
    }
}