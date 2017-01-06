using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogAdoption.Models
{
    public class DogBreedCharacteristic
    {
        public DogBreedCharacteristic(){}

        [Key]
        public int BreedCharacteristicId { get; set; }
        public string BreedName { get; set; }
        public string BreedCharacteristic { get; set; }
        public int BreedCharacteristicValue { get; set; }
    }
}