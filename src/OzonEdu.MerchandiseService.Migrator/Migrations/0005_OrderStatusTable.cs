using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(7)]
    public class OrderStatuses : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists OrderStatus(
                    id SMALLINT PRIMARY KEY
                    name CHARACTER VARYING(63) NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists OrderStatus;");
        }
    }
}