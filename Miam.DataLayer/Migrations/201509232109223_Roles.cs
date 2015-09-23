namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MiamRoles", "MiamUsers_Id", "dbo.MiamUsers");
            DropIndex("dbo.MiamRoles", new[] { "MiamUsers_Id" });
            CreateTable(
                "dbo.MiamRoleMiamUsers",
                c => new
                    {
                        MiamRole_Id = c.Int(nullable: false),
                        MiamUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MiamRole_Id, t.MiamUser_Id })
                .ForeignKey("dbo.MiamRoles", t => t.MiamRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.MiamUsers", t => t.MiamUser_Id, cascadeDelete: true)
                .Index(t => t.MiamRole_Id)
                .Index(t => t.MiamUser_Id);
            
            DropColumn("dbo.MiamRoles", "ApplicationUserId");
            DropColumn("dbo.MiamRoles", "MiamUsers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MiamRoles", "MiamUsers_Id", c => c.Int(nullable: false));
            AddColumn("dbo.MiamRoles", "ApplicationUserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MiamRoleMiamUsers", "MiamUser_Id", "dbo.MiamUsers");
            DropForeignKey("dbo.MiamRoleMiamUsers", "MiamRole_Id", "dbo.MiamRoles");
            DropIndex("dbo.MiamRoleMiamUsers", new[] { "MiamUser_Id" });
            DropIndex("dbo.MiamRoleMiamUsers", new[] { "MiamRole_Id" });
            DropTable("dbo.MiamRoleMiamUsers");
            CreateIndex("dbo.MiamRoles", "MiamUsers_Id");
            AddForeignKey("dbo.MiamRoles", "MiamUsers_Id", "dbo.MiamUsers", "Id", cascadeDelete: true);
        }
    }
}
