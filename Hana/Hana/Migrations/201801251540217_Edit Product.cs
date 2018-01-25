namespace Hana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "LastUpdated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "LastUpdated");
        }
    }
}
