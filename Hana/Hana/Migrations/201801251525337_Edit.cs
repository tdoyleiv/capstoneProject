namespace Hana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ShoppingCarts", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Transactions", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.ShoppingCarts", "Product_ProductID");
            CreateIndex("dbo.Transactions", "Product_ProductID");
            AddForeignKey("dbo.ShoppingCarts", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Transactions", "Product_ProductID", "dbo.Products", "ProductID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.ShoppingCarts", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "Product_ProductID" });
            DropIndex("dbo.ShoppingCarts", new[] { "Product_ProductID" });
            DropColumn("dbo.Transactions", "Product_ProductID");
            DropColumn("dbo.Transactions", "ProductID");
            DropColumn("dbo.ShoppingCarts", "Product_ProductID");
            DropColumn("dbo.ShoppingCarts", "DateCreated");
            DropColumn("dbo.ShoppingCarts", "Count");
            DropColumn("dbo.ShoppingCarts", "ProductID");
        }
    }
}
