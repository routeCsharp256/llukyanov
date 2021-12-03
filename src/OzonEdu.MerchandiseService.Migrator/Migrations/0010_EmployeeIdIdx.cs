using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(10)]
    public class EmployeeIdIdx: ForwardOnlyMigration
    {
        public override void Up()
        {
            Create
                .Index("employee_id_idx")
                .OnTable("Employee")
                .InSchema("public")
                .OnColumn("id");
        }
        
    }
}