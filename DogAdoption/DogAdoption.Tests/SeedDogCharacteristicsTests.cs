using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogAdoption.DAL;
using System.Collections.Generic;

namespace DogAdoption.Tests
{
    [TestClass]
    public class SeedDogCharacteristicsTests
    {
        [TestMethod]
        public void METHODReturnListOfDogBreedsRETURNSListOf50Breeds()
        {
            //Arrange
            SeedDogCharacteristics seed_dog_characteristics = new SeedDogCharacteristics();
            List<string> list_of_dog_breeds = seed_dog_characteristics.ReturnListOfDogBreeds();

            //Act
            int expected_list_length = 50;
            int actual_list_length = list_of_dog_breeds.Count;

            //Assert
            Assert.AreEqual(expected_list_length, actual_list_length);
        }
    }
}
