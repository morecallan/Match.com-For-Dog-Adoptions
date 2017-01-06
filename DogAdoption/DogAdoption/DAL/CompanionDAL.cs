using DogAdoption.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DogAdoption.DAL
{
    public class CompanionRepository
    {
        public CompanionContext Context { get; set; }

        public CompanionRepository() { }
        

        public CompanionRepository(CompanionContext _context)
        {
            Context = _context;
        }


        public List<string> ReturnListOfDogBreeds()
        {
            List<String> AllDogBreeds = new List<string>();
            // Web request to petfinder API
            WebClient client = new WebClient();
            string response = client.DownloadString("https://pet-proxy.herokuapp.com/api/petfinder/breed.list?format=json&animal=dog&key=c292349ff94917231922004072f72865");

            dynamic returnJsonObj = JsonConvert.DeserializeObject(response, typeof(object));
            dynamic breedList = returnJsonObj.petfinder.breeds.breed;
            foreach (var breed in breedList)
            {
                AllDogBreeds.Add(breed["$t"].Value);
            }

            return AllDogBreeds;
        }

        public string DogBreedNameParser(string TempName)
        {
            string[] CharacterArray = TempName.ToLower().Split(' ');
            string AdjustedName = string.Join("-", CharacterArray);
            return AdjustedName;
        }

       public List<DogBreedCharacteristic> CreateListOfBreedCharacteristics()
       {
            List<DogBreedCharacteristic> AllDogCharacteristics = new List<DogBreedCharacteristic>();

            List<string> AllDogBreeds = ReturnListOfDogBreeds();
            foreach (string Breed in AllDogBreeds)
            {

                WebClient client = new WebClient();
                string response = client.DownloadString("https://dogbreed-characteristics.herokuapp.com/dogbreed/?breed=" + DogBreedNameParser(Breed));

          

                if (response != null)
                {
                    dynamic returnJsonObj = JsonConvert.DeserializeObject(response.ToString(), typeof(object));
                    dynamic breedCharacteristicsList = returnJsonObj.characteristics;
                    foreach (var characteristic in breedCharacteristicsList)
                    {
                        DogBreedCharacteristic singleBreedCharacteristic = new DogBreedCharacteristic();
                        singleBreedCharacteristic.BreedName = Breed;
                        singleBreedCharacteristic.BreedCharacteristicId = (int)characteristic.traitId.Value;
                        singleBreedCharacteristic.BreedCharacteristic = characteristic.trait.Value;
                        singleBreedCharacteristic.BreedCharacteristicValue = Int32.Parse(characteristic.value.Value);

                        AllDogCharacteristics.Add(singleBreedCharacteristic);
                    }
                }
     
            }

            return AllDogCharacteristics;
        }

        public void SeedDatabaseWithAllDogBreedCharacteristics()
        {
            List<DogBreedCharacteristic> AllDogBreedCharacteristics = CreateListOfBreedCharacteristics();

            foreach (DogBreedCharacteristic characteristic in AllDogBreedCharacteristics)
            {
                Context.DogBreedCharacteristics.Add(characteristic);
            }
        }

    }
}