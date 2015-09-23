namespace Miam.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roles2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MiamRoleMiamUsers", newName: "MiamUserMiamRoles");
            DropPrimaryKey("dbo.MiamUserMiamRoles");
            AddPrimaryKey("dbo.MiamUserMiamRoles", new[] { "MiamUser_Id", "MiamRole_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MiamUserMiamRoles");
            AddPrimaryKey("dbo.MiamUserMiamRoles", new[] { "MiamRole_Id", "MiamUser_Id" });
            RenameTable(name: "dbo.MiamUserMiamRoles", newName: "MiamRoleMiamUsers");
        }
    }
}
