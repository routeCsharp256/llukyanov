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
        }
    }
}