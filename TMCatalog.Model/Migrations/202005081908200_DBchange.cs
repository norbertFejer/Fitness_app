namespace TMCatalog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientMemberships", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ClientMemberships", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.ClientMemberships", "UserId", "dbo.Users");
            DropForeignKey("dbo.Entrances", new[] { "ClientMembership_ClientId", "ClientMembership_TicketId" }, "dbo.ClientMemberships");
            DropIndex("dbo.ClientMemberships", new[] { "ClientId" });
            DropIndex("dbo.ClientMemberships", new[] { "TicketId" });
            DropIndex("dbo.ClientMemberships", new[] { "UserId" });
            DropIndex("dbo.Entrances", new[] { "ClientMembership_ClientId", "ClientMembership_TicketId" });
            DropTable("dbo.ClientMemberships");
            DropTable("dbo.Clients");
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.Entrances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Entrances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientMembershipId = c.Int(nullable: false),
                        ArrivedTime = c.DateTime(nullable: false),
                        LeftTime = c.DateTime(nullable: false),
                        ClientMembership_ClientId = c.Int(),
                        ClientMembership_TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Type = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        MaxEntrance = c.Short(nullable: false),
                        ValidityNumber = c.Short(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Price = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        DiscountFrom = c.DateTime(nullable: false),
                        DiscountUntil = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        Cnp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        RegisteredDate = c.DateTime(nullable: false),
                        Photo = c.Binary(),
                        Comment = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientMemberships",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        ValidAfter = c.DateTime(nullable: false),
                        EntranceLeft = c.Short(nullable: false),
                        UserId = c.Int(nullable: false),
                        SoldOn = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Price = c.Single(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.ClientId, t.TicketId });
            
            CreateIndex("dbo.Entrances", new[] { "ClientMembership_ClientId", "ClientMembership_TicketId" });
            CreateIndex("dbo.ClientMemberships", "UserId");
            CreateIndex("dbo.ClientMemberships", "TicketId");
            CreateIndex("dbo.ClientMemberships", "ClientId");
            AddForeignKey("dbo.Entrances", new[] { "ClientMembership_ClientId", "ClientMembership_TicketId" }, "dbo.ClientMemberships", new[] { "ClientId", "TicketId" });
            AddForeignKey("dbo.ClientMemberships", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientMemberships", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientMemberships", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
