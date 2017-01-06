using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogAdoption.DAL;
using System.Collections.Generic;
using DogAdoption.Models;

namespace DogAdoption.Tests
{
    [TestClass]
    public class SeedDogCharacteristicsTests
    {
        [TestMethod]
        public void METHODReturnListOfDogBreedsRETURNSListOf50Breeds()
        {
            //Arrange
            CompanionRepository seed_dog_characteristics = new CompanionRepository();
            List<string> list_of_dog_breeds = seed_dog_characteristics.ReturnListOfDogBreeds();

            //Act
            int expected_list_length = 249;
            int actual_list_length = list_of_dog_breeds.Count;

            //Assert
            Assert.AreEqual(expected_list_length, actual_list_length);
        }

        [TestMethod]
        public void METHODDogBreedNameParserRETURNSStringAllLowerAndNoSpaces()
        {
            //Arrange
            string string_before = "Cool Dog";

            CompanionRepository seed_dog_characteristics = new CompanionRepository();
            string adjusted_name = seed_dog_characteristics.DogBreedNameParser(string_before);

            //Act
            string expected_resultant_string = "cool-dog";
            string actual_resultant_string = adjusted_name;

            //Assert
            Assert.AreEqual(expected_resultant_string, actual_resultant_string);
        }

        [TestMethod]
        public void METHODCreateListOfBreedCharacteristicsRETURNSListOf6225Breeds()
        {
            //Arrange
            CompanionRepository seed_dog_characteristics = new CompanionRepository();
            List<DogBreedCharacteristic> list_of_dog_breed_characteristic = seed_dog_characteristics.CreateListOfBreedCharacteristics();

            //Act
            int expected_list_length = 3820;
            int actual_list_length = list_of_dog_breed_characteristic.Count;

            //Assert
            Assert.AreEqual(expected_list_length, actual_list_length);
        }
    }
}
