namespace My.Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4241704 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Places", newName: "SysPlaces");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SysPlaces", newName: "Places");
        }
    }
}
