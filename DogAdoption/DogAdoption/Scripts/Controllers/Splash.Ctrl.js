
app.controller('Splash', function ($scope, $q, Petfinder) {
    $scope.areaDogs = [];

    const limitText = (text) => {
        var shortened = text.split('').slice(140).join('') + `...`;
        return shortened;
    }

    const populateDogObject = (fromPetfinder) => {
        let dogObject = {}
        dogObject.picture = fromPetfinder.media.photos.photo.filter(function (photo) {
            return photo["@size"] == 'x'
        })[0]["$t"];
        dogObject.name = fromPetfinder.name["$t"];
        dogObject.description = limitText(fromPetfinder.description["$t"] || "No description provided.");
        dogObject.link = `https://www.petfinder.com/petdetail/${fromPetfinder.id["$t"]}`
        return dogObject;
    }

    Petfinder.getDogsBasedOnZipCode().then((result) => {

        result.pet.forEach(function (dog) {
            $scope.areaDogs.push(populateDogObject(dog))
        })
    })

})