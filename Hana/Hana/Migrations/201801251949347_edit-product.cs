namespace Hana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ShoppingCart_ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.ShoppingCarts", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Transactions", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "Product_ProductID" });
            DropIndex("dbo.Products", new[] { "ShoppingCart_ShoppingCartID" });
            DropIndex("dbo.Products", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.Transactions", new[] { "Product_ProductID" });
            DropColumn("dbo.ShoppingCarts", "ProductID");
            DropColumn("dbo.Transactions", "ProductID");
            RenameColumn(table: "dbo.ShoppingCarts", name: "Product_ProductID", newName: "ProductID");
            RenameColumn(table: "dbo.Transactions", name: "Product_ProductID", newName: "ProductID");
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TransactionID = c.Int(nullable: false),
                        OrderedProductID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderedProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.TransactionID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.TransactionID);
            
            AddColumn("dbo.ShoppingCarts", "SessionID", c => c.String());
            AlterColumn("dbo.ShoppingCarts", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "ProductID");
            CreateIndex("dbo.Transactions", "ProductID");
            AddForeignKey("dbo.ShoppingCarts", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            DropColumn("dbo.Products", "ShoppingCart_ShoppingCartID");
            DropColumn("dbo.Products", "Transaction_TransactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Transaction_TransactionID", c => c.Int());
            AddColumn("dbo.Products", "ShoppingCart_ShoppingCartID", c => c.Int());
            DropForeignKey("dbo.Transactions", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ShoppingCarts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.OrderedProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductID" });
            DropIndex("dbo.OrderedProducts", new[] { "TransactionID" });
            DropIndex("dbo.OrderedProducts", new[] { "ProductID" });
            DropIndex("dbo.ShoppingCarts", new[] { "ProductID" });
            AlterColumn("dbo.Transactions", "ProductID", c => c.Int());
            AlterColumn("dbo.ShoppingCarts", "ProductID", c => c.Int());
            DropColumn("dbo.ShoppingCarts", "SessionID");
            DropTable("dbo.OrderedProducts");
            RenameColumn(table: "dbo.Transactions", name: "ProductID", newName: "Product_ProductID");
            RenameColumn(table: "dbo.ShoppingCarts", name: "ProductID", newName: "Product_ProductID");
            AddColumn("dbo.Transactions", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "Product_ProductID");
            CreateIndex("dbo.Products", "Transaction_TransactionID");
            CreateIndex("dbo.Products", "ShoppingCart_ShoppingCartID");
            CreateIndex("dbo.ShoppingCarts", "Product_ProductID");
            AddForeignKey("dbo.Transactions", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.ShoppingCarts", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions", "TransactionID");
            AddForeignKey("dbo.Products", "ShoppingCart_ShoppingCartID", "dbo.ShoppingCarts", "ShoppingCartID");
        }
    }
}
