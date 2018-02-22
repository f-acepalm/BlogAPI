namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Text", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 30));
            AlterColumn("dbo.Comments", "Text", c => c.String());
        }
    }
}
