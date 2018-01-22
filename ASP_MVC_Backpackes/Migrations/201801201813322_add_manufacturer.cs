namespace ASP_MVC_Backpackes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_manufacturer : DbMigration
    {
        public override void Up()
        {
             Sql("Insert into Manufacturers (Name, City, NIP, REGON) VALUES ('KOKO','Gdañsk','1234567891','147852145')");
             Sql("Insert into Manufacturers (Name, City, NIP, REGON) VALUES ('Jokoto','Gdynia','9854567891','652852145')");
             Sql("Insert into Manufacturers (Name, City, NIP, REGON) VALUES ('Plecaczeks','Sopot','8524567891','986152145')");
        }

        public override void Down()
        {
        }
    }
}
