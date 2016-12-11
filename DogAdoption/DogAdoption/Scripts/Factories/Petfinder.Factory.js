app.factory('Petfinder', function ($q, $http, Geolocation) {
    const key = "c292349ff94917231922004072f72865";
    const petfinderProxyUrl = `https://pet-proxy.herokuapp.com/api/petfinder`

    const getDogsBasedOnZipCode = () => {
        return $q(function (resolve, reject) {
            
        
            Geolocation.GetZipFromLatAndLong().then(function(zip) {
                console.log(zip)

                var url = `${petfinderProxyUrl}/pet.find?key=${key}&format=json&location=${zip}&animal=dog`;

                $http.get(url).success(function (response) {
                    console.log(response)
                    resolve(response.petfinder.pets);
                }).error(reject);

            })
            
        })
    }


    return { getDogsBasedOnZipCode: getDogsBasedOnZipCode }
})