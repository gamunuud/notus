using System.Data.Entity.Migrations;

namespace Notus.Portal.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalenderEvents",
                c => new
                {
                    Id = c.Int(false, true),
                    Title = c.String(),
                    Start = c.DateTime(false),
                    End = c.DateTime(false),
                    AllDay = c.Boolean(false),
                    ClassName = c.String(),
                    Url = c.String(),
                    User_Id = c.String(maxLength: 128)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.String(false, 128),
                    Email = c.String(),
                    EmailConfirmed = c.Boolean(false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(false),
                    TwoFactorEnabled = c.Boolean(false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(false),
                    AccessFailedCount = c.Int(false),
                    UserName = c.String(),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Country = c.String(),
                    Gender = c.String(),
                    BirthDate = c.DateTime(),
                    Discriminator = c.String(false, 128)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserClaims",
                c => new
                {
                    Id = c.Int(false, true),
                    UserId = c.String(),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    IdentityUser_Id = c.String(maxLength: 128)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);

            CreateTable(
                "dbo.UserLogins",
                c => new
                {
                    LoginProvider = c.String(false, 128),
                    ProviderKey = c.String(false, 128),
                    UserId = c.String(false, 128),
                    IdentityUser_Id = c.String(maxLength: 128)
                })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);

            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    UserId = c.String(false, 128),
                    RoleId = c.String(false, 128),
                    IdentityUser_Id = c.String(maxLength: 128)
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.Roles", t => t.RoleId, true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Id = c.Int(false, true),
                    Code = c.String(),
                    Name = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Id = c.String(false, 128),
                    Name = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.CalenderEvents", "User_Id", "dbo.Users");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] {"IdentityUser_Id"});
            DropIndex("dbo.UserRoles", new[] {"RoleId"});
            DropIndex("dbo.UserLogins", new[] {"IdentityUser_Id"});
            DropIndex("dbo.UserClaims", new[] {"IdentityUser_Id"});
            DropIndex("dbo.CalenderEvents", new[] {"User_Id"});
            DropTable("dbo.Roles");
            DropTable("dbo.Countries");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.CalenderEvents");
        }
    }
}