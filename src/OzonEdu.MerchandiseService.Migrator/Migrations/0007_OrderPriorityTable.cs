using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(20)]
    public class OrderPriorities : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists OrderPriority(
                    id SMALLINT PRIMARY KEY
                    name CHARACTER VARYING(63) NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists OrderPriority;");
        }
    }
}