namespace My.Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4241647 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        ParentCode = c.String(nullable: false, maxLength: 50),
                        Deep = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Places");
        }
    }
}
