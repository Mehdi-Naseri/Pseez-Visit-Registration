namespace Pseez.VisitRegistration.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Management.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Message = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Registration.Registration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        IPECUsername = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        TelephoneNumber = c.String(nullable: false, maxLength: 50),
                        Mobile = c.String(nullable: false, maxLength: 50),
                        FaxNumber = c.String(),
                        Address = c.String(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyPhone = c.String(nullable: false, maxLength: 50),
                        CompanyAddress = c.String(nullable: false),
                        RegistrationDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Identity.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Identity.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Identity.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Identity.AspNetUsers",
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
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Identity.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Identity.AspNetUserRoles", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserLogins", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserClaims", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserRoles", "RoleId", "Identity.AspNetRoles");
            DropIndex("Identity.AspNetUserLogins", new[] { "UserId" });
            DropIndex("Identity.AspNetUserClaims", new[] { "UserId" });
            DropIndex("Identity.AspNetUsers", "UserNameIndex");
            DropIndex("Identity.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("Identity.AspNetUserRoles", new[] { "UserId" });
            DropIndex("Identity.AspNetRoles", "RoleNameIndex");
            DropTable("Identity.AspNetUserLogins");
            DropTable("Identity.AspNetUserClaims");
            DropTable("Identity.AspNetUsers");
            DropTable("Identity.AspNetUserRoles");
            DropTable("Identity.AspNetRoles");
            DropTable("Registration.Registration");
            DropTable("Management.Log");
        }
    }
}
