using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(7)]
    public class MerchOrderStatuses : Migration
    {
        public override void Up()
        {
            Create
                .Table("MerchOrderStatus")
                .WithColumn("id").AsInt16().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("MerchOrderStatus");
        }
    }
}