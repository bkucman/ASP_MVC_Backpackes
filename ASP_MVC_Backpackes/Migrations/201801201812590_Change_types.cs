namespace ASP_MVC_Backpackes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_types : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Manufacturers", "NIP", c => c.String());
            AlterColumn("dbo.Manufacturers", "REGON", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturers", "REGON", c => c.Int(nullable: false));
            AlterColumn("dbo.Manufacturers", "NIP", c => c.Int(nullable: false));
        }
    }
}
