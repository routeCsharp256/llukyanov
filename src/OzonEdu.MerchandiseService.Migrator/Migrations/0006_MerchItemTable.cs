using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(8)]
    public class MerchItemTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists MerchItem(
                    sku BIGINT PRIMARY KEY,
                    name CHARACTER VARYING(255) NOT NULL,
                    description TEXT NOT NULL,
                    item_type_id SMALLINT NOT NULL,
                    tags CHARACTER VARYING[] NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists MerchItem;");
        }
    }
}