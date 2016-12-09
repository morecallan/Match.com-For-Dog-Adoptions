app.factory('Geolocation', function ($q, $window, $http) {
    let GetLatAndLong = () => {
        return $q(function (resolve, reject) {
            if (!$window.navigator) {
                reject(new Error('Geolocation is not supported'));
            } else {
                $window.navigator.geolocation.getCurrentPosition(function (position) {
                    var latLong = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    }
                    resolve(latLong);
                });
            }
        })
    }

    let GetZipFromLatAndLong = () => {
        return $q(function (resolve, reject) {
            GetLatAndLong().then((position) => {
                var url = `http://maps.google.com/maps/api/geocode/json?latlng=${position.lat},${position.lng}&sensor=false`;

                $http.get(url).success(function (response) {
                    var zipCode;
                    response.results.forEach(function (result) {
                        if (result.types[0] === 'postal_code') {
                            zipCode = result.address_components[0].short_name;
                        }
                    });
                    resolve(zipCode);
                }).error(reject);
            })
        })
    }


    return { GetLatAndLong: GetLatAndLong, GetZipFromLatAndLong: GetZipFromLatAndLong }
})
