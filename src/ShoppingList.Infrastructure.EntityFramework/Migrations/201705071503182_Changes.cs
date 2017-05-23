namespace ShoppingList.Infrastructure.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Purchases", "Tax_Id", c => c.Int());
            CreateIndex("dbo.Purchases", "Tax_Id");
            AddForeignKey("dbo.Purchases", "Tax_Id", "dbo.Taxes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "Tax_Id", "dbo.Taxes");
            DropIndex("dbo.Purchases", new[] { "Tax_Id" });
            DropColumn("dbo.Purchases", "Tax_Id");
            DropTable("dbo.Taxes");
        }
    }
}
