using DogAdoption.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DogAdoption.DAL
{
    public class SeedDogCharacteristics
    {
        public SeedDogCharacteristics() { }
        public List<String> ReturnListOfDogBreeds()
        {
            List<String> AllDogBreeds = new List<string>();
            // Web request to petfinder API
            WebClient client = new WebClient();
            string response = client.DownloadString("https://pet-proxy.herokuapp.com/api/petfinder/breed.list?format=json&animal=dog&key=c292349ff94917231922004072f72865");

            dynamic returnJsonObj = JsonConvert.DeserializeObject(response);
            dynamic breedList = returnJsonObj.petfinder.breeds.breed;
            foreach (var breed in breedList)
            {
                AllDogBreeds.Add(breed.Value);
            }

            return AllDogBreeds;
        }

        public string DogBreedNameParser(string TempName)
        {
            string[] CharacterArray = TempName.ToLower().Split(' ');
            string AdjustedName = string.Join("", CharacterArray);
            return AdjustedName;
        }

       public List<DogBreedCharacteristic> CreateListOfBreedCharacteristics()
       {
            List<DogBreedCharacteristic> AllDogCharacteristics = new List<DogBreedCharacteristic>();
            string DogBreedNameParsed;

            List<String> AllDogBreeds = ReturnListOfDogBreeds();
            foreach (string Breed in AllDogBreeds)
            {
                DogBreedNameParsed = DogBreedNameParser(Breed);


                WebRequest request = WebRequest.Create("https://dogbreed-characteristics.herokuapp.com/dogbreed/?breed=" + DogBreedNameParsed);
                WebResponse response = request.GetResponse();

                dynamic returnJsonObj = JsonConvert.DeserializeObject(response.ToString());
                dynamic breedCharacteristicsList = returnJsonObj.characteristics;
                foreach (var characteristic in breedCharacteristicsList)
                {
                    DogBreedCharacteristic singleBreedCharacteristic = new DogBreedCharacteristic();
                    singleBreedCharacteristic.BreedName = Breed;
                    singleBreedCharacteristic.BreedCharacteristicId = characteristic.traitId.Value;
                    singleBreedCharacteristic.BreedCharacteristic = characteristic.trait.Value;
                    singleBreedCharacteristic.BreedCharacteristicValue = characteristic.value.Value;

                    AllDogCharacteristics.Add(singleBreedCharacteristic);
                }

       
            }

            return AllDogCharacteristics;
        }
    }
}