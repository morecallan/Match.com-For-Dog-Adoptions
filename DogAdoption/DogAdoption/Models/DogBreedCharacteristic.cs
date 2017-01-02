using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogAdoption.Models
{
    public class DogBreedCharacteristic
    {
        public DogBreedCharacteristic()
        {

        }

        public string BreedName { get; set; }
        public int BreedCharacteristicId { get; set; }
        public string BreedCharacteristic { get; set; }
        public int BreedCharacteristicValue { get; set; }
    }
}