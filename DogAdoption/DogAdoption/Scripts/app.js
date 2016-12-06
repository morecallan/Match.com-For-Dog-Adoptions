"use strict";

var app = angular.module('Companion', []);

app.controller('Splash', function ($scope, Geolocation) {
    Geolocation.GetZipFromLatAndLong().then((result) => {console.log(result)})

})

app.factory('Geolocation', function ($q, $window, $http) {
    const GetLatAndLong = () => {
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

    const GetZipFromLatAndLong = () => {
        return $q(function(resolve, reject){
            GetLatAndLong().then((position) => {
                console.log("hello")
                var url = `http://maps.google.com/maps/api/geocode/json?latlng=${position.lat},${position.lng}&sensor=false`;

                $http.get(url).success(function (response) {
                    var zipCode;
                    angular.forEach(response.results, function (result) {
                        if (result.types[0] === 'postal_code') {
                            zipCode = result.address_components[0].short_name;
                        }
                    });
                    resolve(zipCode);
                }).error(reject());
            })
        })    
    }


    return { GetLatAndLong, GetZipFromLatAndLong}
})