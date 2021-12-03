using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(5)]
    public class MerchItemTypes : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists MerchItemType(
                    id SMALLINT PRIMARY KEY
                    name CHARACTER VARYING(255) NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists MerchItemType;");
        }
    }
}