using DogAdoption.Models;
using System.Data.Entity;

namespace DogAdoption.DAL
{
    public class CompanionContext : DbContext
    {
        public virtual DbSet<DogBreedCharacteristic> DogBreedCharacteristics { get; set; }
    }
}
