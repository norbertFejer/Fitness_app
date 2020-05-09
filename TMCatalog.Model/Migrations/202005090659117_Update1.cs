namespace TMCatalog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientMemberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        ValidAfter = c.DateTime(nullable: false),
                        EntranceLeft = c.Short(nullable: false),
                        UserId = c.Int(nullable: false),
                        SoldOn = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Price = c.Single(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.TicketId)
                .Index(t => t.UserId);
            
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
                "dbo.Entrances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientMembershipId = c.Int(nullable: false),
                        ArrivedTime = c.DateTime(nullable: false),
                        LeftTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientMemberships", t => t.ClientMembershipId, cascadeDelete: true)
                .Index(t => t.ClientMembershipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entrances", "ClientMembershipId", "dbo.ClientMemberships");
            DropForeignKey("dbo.ClientMemberships", "UserId", "dbo.Users");
            DropForeignKey("dbo.ClientMemberships", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.ClientMemberships", "ClientId", "dbo.Clients");
            DropIndex("dbo.Entrances", new[] { "ClientMembershipId" });
            DropIndex("dbo.ClientMemberships", new[] { "UserId" });
            DropIndex("dbo.ClientMemberships", new[] { "TicketId" });
            DropIndex("dbo.ClientMemberships", new[] { "ClientId" });
            DropTable("dbo.Entrances");
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientMemberships");
        }
    }
}
