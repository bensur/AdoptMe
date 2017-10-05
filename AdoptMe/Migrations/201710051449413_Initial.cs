namespace AdoptMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdoptionAgencyModels",
                c => new
                    {
                        AdoptionAgencyID = c.Int(nullable: false, identity: true),
                        AdoptionAgencyName = c.String(),
                        AdoptionAgencyLocationLat = c.Int(nullable: false),
                        AdoptionAgencyLocationLng = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdoptionAgencyID);
            
            CreateTable(
                "dbo.AnimalModels",
                c => new
                    {
                        AnimalID = c.Int(nullable: false, identity: true),
                        AnimalName = c.String(),
                        AnimalType = c.String(),
                        AnimalBreed = c.String(),
                        AnimalColor = c.String(),
                        AnimalAge = c.Int(nullable: false),
                        AnimalAdoptionAgency_AdoptionAgencyID = c.Int(),
                    })
                .PrimaryKey(t => t.AnimalID)
                .ForeignKey("dbo.AdoptionAgencyModels", t => t.AnimalAdoptionAgency_AdoptionAgencyID)
                .Index(t => t.AnimalAdoptionAgency_AdoptionAgencyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnimalModels", "AnimalAdoptionAgency_AdoptionAgencyID", "dbo.AdoptionAgencyModels");
            DropIndex("dbo.AnimalModels", new[] { "AnimalAdoptionAgency_AdoptionAgencyID" });
            DropTable("dbo.AnimalModels");
            DropTable("dbo.AdoptionAgencyModels");
        }
    }
}
