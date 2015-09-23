namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomDeLaMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "AAA",  c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "AAA");
        }
    }
}
