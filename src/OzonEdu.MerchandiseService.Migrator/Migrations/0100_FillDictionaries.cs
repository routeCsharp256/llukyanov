using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Temp
{
    [Migration(100)]
    public class FillDictionaries : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO MerchItemType (id, name)
                VALUES 
                    (1, 'TShirt'),
                    (2, 'Sweatshirt'),
                    (3, 'Notepad'),
                    (4, 'Bag'),
                    (5, 'Pen'),
                    (6, 'Socks')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO OrderStatus (id, name)
                VALUES 
                    (1, 'New'),
                    (2, 'Active'),
                    (3, 'Prepared'),
                    (4, 'Closed'),
                    (10, 'Cancelled')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO OrderPriority (id, name)
                VALUES 
                    (1, 'Low'),
                    (2, 'Medium'),
                    (3, 'High'),
                    (10, 'Critical')
                ON CONFLICT DO NOTHING
            ");
        }
    }
}