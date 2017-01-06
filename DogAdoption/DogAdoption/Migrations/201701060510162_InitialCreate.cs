namespace DogAdoption.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DogBreedCharacteristics",
                c => new
                    {
                        BreedCharacteristicUniqueId = c.Int(nullable: false, identity: true),
                        BreedName = c.String(),
                        BreedCharacteristicId = c.Int(nullable: false),
                        BreedCharacteristic = c.String(),
                        BreedCharacteristicValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BreedCharacteristicUniqueId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DogBreedCharacteristics");
        }
    }
}
