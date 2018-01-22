namespace ASP_MVC_Backpackes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_require : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "NIP", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "REGON", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturers", "REGON", c => c.String());
            AlterColumn("dbo.Manufacturers", "NIP", c => c.String());
            AlterColumn("dbo.Manufacturers", "City", c => c.String());
            AlterColumn("dbo.Manufacturers", "Name", c => c.String());
        }
    }
}
