namespace AdoptMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAgencyLocationToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdoptionAgencyModels", "AdoptionAgencyLocationLat", c => c.Single(nullable: false));
            AlterColumn("dbo.AdoptionAgencyModels", "AdoptionAgencyLocationLng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdoptionAgencyModels", "AdoptionAgencyLocationLng", c => c.Int(nullable: false));
            AlterColumn("dbo.AdoptionAgencyModels", "AdoptionAgencyLocationLat", c => c.Int(nullable: false));
        }
    }
}
