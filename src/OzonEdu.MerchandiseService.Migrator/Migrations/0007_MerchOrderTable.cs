using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(7)]
    public class MerchOrderTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists MerchOrder(
                    id BIGINT IDENTITY PRIMARY KEY,
                    employee_id INT NOT NULL,
                    skus_requested long[] NOT NULL,
                    skus_reserved long[],
                    merch_pack_id SMALLINT,
                    status SMALLINT NOT NULL,
                    priority SMALLINT NOT NULL,
                    created_at TIMESTAMP WITHOUT TIME ZONE NOT NULL,
                    closed_at TIMESTAMP WITHOUT TIME ZONE,
                    deadline TIMESTAMP WITHOUT TIME ZONE,
                    manager_id INT,
                    is_employee_received_order BIT);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists MerchOrder;");
        }
    }
}