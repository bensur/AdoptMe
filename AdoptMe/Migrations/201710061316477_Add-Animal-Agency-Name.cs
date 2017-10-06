namespace AdoptMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalAgencyName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnimalModels", "AnimalAgencyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnimalModels", "AnimalAgencyName");
        }
    }
}
