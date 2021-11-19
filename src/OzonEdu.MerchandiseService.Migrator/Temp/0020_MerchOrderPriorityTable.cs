using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(20)]
    public class MerchOrderPriorities : Migration
    {
        public override void Up()
        {
            Create
                .Table("MerchOrderPriority")
                .WithColumn("id").AsInt16().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("MerchOrderPriority");
        }
    }
}