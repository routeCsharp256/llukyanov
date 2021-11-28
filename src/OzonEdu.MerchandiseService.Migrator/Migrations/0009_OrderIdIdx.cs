using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(9)]
    public class DeliveryRequestsRequestIdId: ForwardOnlyMigration
    {
        public override void Up()
        {
            Create
                .Index("merch_order_id_idx")
                .OnTable("Order")
                .InSchema("public")
                .OnColumn("id");
        }
        
    }
}