namespace DogAdoption.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DogAdoption.DAL.CompanionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DogAdoption.DAL.CompanionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            CompanionRepository repo = new CompanionRepository();

            List<DogBreedCharacteristic> AllDogBreedCharacteristics = repo.CreateListOfBreedCharacteristics();

            foreach (DogBreedCharacteristic characteristic in AllDogBreedCharacteristics)
            {
                context.DogBreedCharacteristics.AddOrUpdate(characteristic);
            }
        }
    }
}
