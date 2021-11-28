using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(6)]
    public class MerchPacks : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists MerchPackInfo(
                    id INT PRIMARY KEY,
                    name CHARACTER VARYING(63) NOT NULL,
                    employee_event_id SMALLINT NOT NULL,
                    is_conference BIT NOT NULL,
                    merch_item_skus CHARACTER VARYING(127)[] NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists MerchPackInfo;");
        }
    }
}