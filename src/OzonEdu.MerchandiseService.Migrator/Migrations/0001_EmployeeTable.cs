using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(1)]
    public class EmployeeTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists Employee(
                    id INT PRIMARY KEY,
                    full_name CHARACTER VARYING(255) NOT NULL,
                    department CHARACTER VARYING(255) NOT NULL,
                    email CHARACTER VARYING(127) NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql("DROP TABLE if exists Employee;");
        }
    }
}