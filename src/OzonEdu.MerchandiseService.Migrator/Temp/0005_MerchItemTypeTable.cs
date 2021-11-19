using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(5)]
    public class MerchItemTypes : Migration
    {
        public override void Up()
        {
            Create
                .Table("MerchItemType")
                .WithColumn("id").AsInt16().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("MerchItemType");
        }
    }
}