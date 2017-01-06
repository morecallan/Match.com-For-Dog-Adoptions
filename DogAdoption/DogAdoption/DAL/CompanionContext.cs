using DogAdoption.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogAdoption.DAL
{
    public class CompanionContext : DbContext
    {
        public virtual DbSet<DogBreedCharacteristic> DogBreedCharacteristics { get; set; }
    }
}
