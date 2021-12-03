using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(12)]
    public class ManagerIdIdx: ForwardOnlyMigration
    {
        public override void Up()
        {
            Create
                .Index("manager_id_idx")
                .OnTable("Manager")
                .InSchema("public")
                .OnColumn("id");
        }
    }
}