using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(2)]
    public class Conference : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists Conference(
                    id INT PRIMARY KEY,
                    name CHARACTER VARYING(255) NOT NULL,
                    date TIMESTAMP WITH TIME ZONE NOT NULL,
                    description TEXT);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists Conference;");
        }
    }
}