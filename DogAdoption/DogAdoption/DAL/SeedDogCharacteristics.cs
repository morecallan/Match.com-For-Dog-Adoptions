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
        public List<String> ReturnListOfDogBreeds()
        {
            List<String> AllDogBreeds = new List<string>();
            // Web request to petfinder API
            WebRequest request = WebRequest.Create("https://pet-proxy.herokuapp.com/api/petfinder/breed.list?format=json&animal=dog&key=c292349ff94917231922004072f72865");
            WebResponse response = request.GetResponse();

            dynamic breedList = JsonConvert.DeserializeObject(response.ToString());
            
            foreach (var breed in breedList)
            {
                AllDogBreeds.Add(breed);
            }

            return AllDogBreeds;
        }

    }
}