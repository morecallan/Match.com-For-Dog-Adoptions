
app.controller('Splash', function ($scope, $q, Petfinder) {
    Petfinder.getDogsBasedOnZipCode().then((result) => { console.log(result) })

})