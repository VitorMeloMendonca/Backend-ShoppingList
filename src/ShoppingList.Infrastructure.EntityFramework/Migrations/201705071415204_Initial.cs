namespace ShoppingList.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Supermarket_Id = c.Int(),
                        UserGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supermarkets", t => t.Supermarket_Id)
                .ForeignKey("dbo.UserGroups", t => t.UserGroup_Id, cascadeDelete: true)
                .Index(t => t.Supermarket_Id)
                .Index(t => t.UserGroup_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Observation = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        ItemProduct_Id = c.Int(),
                        Purchase_Id = c.Int(),
                        ShoppingList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemProducts", t => t.ItemProduct_Id)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_Id)
                .Index(t => t.ItemProduct_Id)
                .Index(t => t.Purchase_Id)
                .Index(t => t.ShoppingList_Id);
            
            CreateTable(
                "dbo.ItemProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supermarkets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        UserGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserGroups", t => t.UserGroup_Id, cascadeDelete: true)
                .Index(t => t.UserGroup_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Profile_Id = c.Int(),
                        UserGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .ForeignKey("dbo.UserGroups", t => t.UserGroup_Id)
                .Index(t => t.Profile_Id)
                .Index(t => t.UserGroup_Id);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserGroup_Id", "dbo.UserGroups");
            DropForeignKey("dbo.ShoppingLists", "UserGroup_Id", "dbo.UserGroups");
            DropForeignKey("dbo.Purchases", "UserGroup_Id", "dbo.UserGroups");
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Items", "ShoppingList_Id", "dbo.ShoppingLists");
            DropForeignKey("dbo.Purchases", "Supermarket_Id", "dbo.Supermarkets");
            DropForeignKey("dbo.Items", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.Items", "ItemProduct_Id", "dbo.ItemProducts");
            DropIndex("dbo.Users", new[] { "UserGroup_Id" });
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            DropIndex("dbo.ShoppingLists", new[] { "UserGroup_Id" });
            DropIndex("dbo.Items", new[] { "ShoppingList_Id" });
            DropIndex("dbo.Items", new[] { "Purchase_Id" });
            DropIndex("dbo.Items", new[] { "ItemProduct_Id" });
            DropIndex("dbo.Purchases", new[] { "UserGroup_Id" });
            DropIndex("dbo.Purchases", new[] { "Supermarket_Id" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.Users");
            DropTable("dbo.ShoppingLists");
            DropTable("dbo.Profiles");
            DropTable("dbo.Products");
            DropTable("dbo.Supermarkets");
            DropTable("dbo.ItemProducts");
            DropTable("dbo.Items");
            DropTable("dbo.Purchases");
        }
    }
}
