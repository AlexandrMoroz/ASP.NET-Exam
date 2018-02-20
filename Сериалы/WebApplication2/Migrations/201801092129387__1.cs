namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cookies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CookieSerials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CookieId = c.Int(nullable: false),
                        SerialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cookies", t => t.CookieId, cascadeDelete: true)
                .ForeignKey("dbo.Serials", t => t.SerialId, cascadeDelete: true)
                .Index(t => t.CookieId)
                .Index(t => t.SerialId);
            
            CreateTable(
                "dbo.Serials",
                c => new
                    {
                        SerialId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Name = c.String(nullable: false),
                        EnglishName = c.String(),
                        Coments = c.String(nullable: false),
                        YearsOfEdition = c.String(),
                        Time = c.String(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        StudioId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialId)
                .ForeignKey("dbo.Directors", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.Studios", t => t.StudioId, cascadeDelete: true)
                .Index(t => t.DirectorId)
                .Index(t => t.StudioId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SerialGaners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialId = c.Int(nullable: false),
                        GanerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ganers", t => t.GanerId, cascadeDelete: true)
                .ForeignKey("dbo.Serials", t => t.SerialId, cascadeDelete: true)
                .Index(t => t.SerialId)
                .Index(t => t.GanerId);
            
            CreateTable(
                "dbo.Ganers",
                c => new
                    {
                        GanerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GanerId);
            
            CreateTable(
                "dbo.SerialSeazons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeazonId = c.Int(),
                        SerialId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seazons", t => t.SeazonId)
                .ForeignKey("dbo.Serials", t => t.SerialId)
                .Index(t => t.SeazonId)
                .Index(t => t.SerialId);
            
            CreateTable(
                "dbo.Seazons",
                c => new
                    {
                        SeazonId = c.Int(nullable: false, identity: true),
                        Number = c.Int(),
                    })
                .PrimaryKey(t => t.SeazonId);
            
            CreateTable(
                "dbo.Serias",
                c => new
                    {
                        SeriaId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        SeazonSerial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SeriaId)
                .ForeignKey("dbo.SerialSeazons", t => t.SeazonSerial_Id)
                .Index(t => t.SeazonSerial_Id);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSerials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        SerialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Serials", t => t.SerialId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.SerialId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CountrySerials",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        Serial_SerialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.Serial_SerialId })
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.Serials", t => t.Serial_SerialId, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.Serial_SerialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserSerials", "SerialId", "dbo.Serials");
            DropForeignKey("dbo.UserSerials", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Serials", "StudioId", "dbo.Studios");
            DropForeignKey("dbo.Serias", "SeazonSerial_Id", "dbo.SerialSeazons");
            DropForeignKey("dbo.SerialSeazons", "SerialId", "dbo.Serials");
            DropForeignKey("dbo.SerialSeazons", "SeazonId", "dbo.Seazons");
            DropForeignKey("dbo.SerialGaners", "SerialId", "dbo.Serials");
            DropForeignKey("dbo.SerialGaners", "GanerId", "dbo.Ganers");
            DropForeignKey("dbo.CookieSerials", "SerialId", "dbo.Serials");
            DropForeignKey("dbo.Serials", "DirectorId", "dbo.Directors");
            DropForeignKey("dbo.CountrySerials", "Serial_SerialId", "dbo.Serials");
            DropForeignKey("dbo.CountrySerials", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.CookieSerials", "CookieId", "dbo.Cookies");
            DropIndex("dbo.CountrySerials", new[] { "Serial_SerialId" });
            DropIndex("dbo.CountrySerials", new[] { "Country_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserSerials", new[] { "SerialId" });
            DropIndex("dbo.UserSerials", new[] { "ApplicationUserId" });
            DropIndex("dbo.Serias", new[] { "SeazonSerial_Id" });
            DropIndex("dbo.SerialSeazons", new[] { "SerialId" });
            DropIndex("dbo.SerialSeazons", new[] { "SeazonId" });
            DropIndex("dbo.SerialGaners", new[] { "GanerId" });
            DropIndex("dbo.SerialGaners", new[] { "SerialId" });
            DropIndex("dbo.Serials", new[] { "StudioId" });
            DropIndex("dbo.Serials", new[] { "DirectorId" });
            DropIndex("dbo.CookieSerials", new[] { "SerialId" });
            DropIndex("dbo.CookieSerials", new[] { "CookieId" });
            DropTable("dbo.CountrySerials");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserSerials");
            DropTable("dbo.Studios");
            DropTable("dbo.Serias");
            DropTable("dbo.Seazons");
            DropTable("dbo.SerialSeazons");
            DropTable("dbo.Ganers");
            DropTable("dbo.SerialGaners");
            DropTable("dbo.Directors");
            DropTable("dbo.Countries");
            DropTable("dbo.Serials");
            DropTable("dbo.CookieSerials");
            DropTable("dbo.Cookies");
        }
    }
}
