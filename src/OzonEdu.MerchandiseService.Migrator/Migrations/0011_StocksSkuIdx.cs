using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(11, TransactionBehavior.None)]
    public class StocksSkuIdx: ForwardOnlyMigration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE INDEX CONCURRENTLY stocks_sku_id_idx ON stocks (sku_id)"
            );
        }
    }
}