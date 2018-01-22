namespace Hana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingAddresses",
                c => new
                    {
                        BillingAddressID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        CityID = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        ZIPID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillingAddressID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.StateID, cascadeDelete: true)
                .ForeignKey("dbo.ZIPs", t => t.ZIPID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.StateID)
                .Index(t => t.ZIPID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.ZIPs",
                c => new
                    {
                        ZIPID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ZIPID);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        Cardholder = c.String(nullable: false),
                        CCNumber = c.String(nullable: false),
                        BillingAddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.BillingAddresses", t => t.BillingAddressID, cascadeDelete: true)
                .Index(t => t.BillingAddressID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumberID = c.Int(nullable: false),
                        ShoppingCartID = c.Int(nullable: false),
                        EmailAddressID = c.Int(nullable: false),
                        ShippingAddressID = c.Int(nullable: false),
                        BillingAddressID = c.Int(nullable: false),
                        CreditCardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.BillingAddresses", t => t.BillingAddressID, cascadeDelete: true)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardID, cascadeDelete: false)
                .ForeignKey("dbo.EmailAddresses", t => t.EmailAddressID, cascadeDelete: true)
                .ForeignKey("dbo.PhoneNumbers", t => t.PhoneNumberID, cascadeDelete: true)
                .ForeignKey("dbo.ShippingAddresses", t => t.ShippingAddressID, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartID, cascadeDelete: true)
                .Index(t => t.PhoneNumberID)
                .Index(t => t.ShoppingCartID)
                .Index(t => t.EmailAddressID)
                .Index(t => t.ShippingAddressID)
                .Index(t => t.BillingAddressID)
                .Index(t => t.CreditCardID);
            
            CreateTable(
                "dbo.EmailAddresses",
                c => new
                    {
                        EmailAddressID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmailAddressID);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        PhoneNumberID = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumberID);
            
            CreateTable(
                "dbo.ShippingAddresses",
                c => new
                    {
                        ShippingAddressID = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        CityID = c.Int(nullable: false),
                        StateID = c.Int(nullable: false),
                        ZIPID = c.Int(nullable: false),
                        IsBilling = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingAddressID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateID, cascadeDelete: false)
                .ForeignKey("dbo.ZIPs", t => t.ZIPID, cascadeDelete: false)
                .Index(t => t.CityID)
                .Index(t => t.StateID)
                .Index(t => t.ZIPID);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartID = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductTypeID = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SizeID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsSoldOut = c.Boolean(nullable: false),
                        ShoppingCart_ShoppingCartID = c.Int(),
                        Store_StoreID = c.Int(),
                        Transaction_TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Sizes", t => t.SizeID, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_ShoppingCartID)
                .ForeignKey("dbo.Stores", t => t.Store_StoreID)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID)
                .Index(t => t.ProductTypeID)
                .Index(t => t.SizeID)
                .Index(t => t.ShoppingCart_ShoppingCartID)
                .Index(t => t.Store_StoreID)
                .Index(t => t.Transaction_TransactionID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SizeID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.StoreID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        CreditCardID = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Time = c.DateTime(nullable: false),
                        Store_StoreID = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: false)
                .ForeignKey("dbo.Stores", t => t.Store_StoreID)
                .Index(t => t.CustomerID)
                .Index(t => t.CreditCardID)
                .Index(t => t.Store_StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Store_StoreID", "dbo.Stores");
            DropForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Transactions", "CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.Products", "Store_StoreID", "dbo.Stores");
            DropForeignKey("dbo.Customers", "ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Products", "ShoppingCart_ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Products", "SizeID", "dbo.Sizes");
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.Customers", "ShippingAddressID", "dbo.ShippingAddresses");
            DropForeignKey("dbo.ShippingAddresses", "ZIPID", "dbo.ZIPs");
            DropForeignKey("dbo.ShippingAddresses", "StateID", "dbo.States");
            DropForeignKey("dbo.ShippingAddresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Customers", "PhoneNumberID", "dbo.PhoneNumbers");
            DropForeignKey("dbo.Customers", "EmailAddressID", "dbo.EmailAddresses");
            DropForeignKey("dbo.Customers", "CreditCardID", "dbo.CreditCards");
            DropForeignKey("dbo.Customers", "BillingAddressID", "dbo.BillingAddresses");
            DropForeignKey("dbo.CreditCards", "BillingAddressID", "dbo.BillingAddresses");
            DropForeignKey("dbo.BillingAddresses", "ZIPID", "dbo.ZIPs");
            DropForeignKey("dbo.BillingAddresses", "StateID", "dbo.States");
            DropForeignKey("dbo.BillingAddresses", "CityID", "dbo.Cities");
            DropIndex("dbo.Transactions", new[] { "Store_StoreID" });
            DropIndex("dbo.Transactions", new[] { "CreditCardID" });
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "Transaction_TransactionID" });
            DropIndex("dbo.Products", new[] { "Store_StoreID" });
            DropIndex("dbo.Products", new[] { "ShoppingCart_ShoppingCartID" });
            DropIndex("dbo.Products", new[] { "SizeID" });
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropIndex("dbo.ShippingAddresses", new[] { "ZIPID" });
            DropIndex("dbo.ShippingAddresses", new[] { "StateID" });
            DropIndex("dbo.ShippingAddresses", new[] { "CityID" });
            DropIndex("dbo.Customers", new[] { "CreditCardID" });
            DropIndex("dbo.Customers", new[] { "BillingAddressID" });
            DropIndex("dbo.Customers", new[] { "ShippingAddressID" });
            DropIndex("dbo.Customers", new[] { "EmailAddressID" });
            DropIndex("dbo.Customers", new[] { "ShoppingCartID" });
            DropIndex("dbo.Customers", new[] { "PhoneNumberID" });
            DropIndex("dbo.CreditCards", new[] { "BillingAddressID" });
            DropIndex("dbo.BillingAddresses", new[] { "ZIPID" });
            DropIndex("dbo.BillingAddresses", new[] { "StateID" });
            DropIndex("dbo.BillingAddresses", new[] { "CityID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Stores");
            DropTable("dbo.Sizes");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.EmailAddresses");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditCards");
            DropTable("dbo.ZIPs");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.BillingAddresses");
        }
    }
}
