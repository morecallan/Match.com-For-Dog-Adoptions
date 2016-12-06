"use strict";

var app = angular.module('Companion', []);

app.controller('Splash', function ($scope) {

})

app.factory('Geolocation', function ($q, $window) {
    const GetLatAndLong = () => {
        return $q(function (resolve, reject) {
            if (!$window.navigator) {
                reject(new Error('Geolocation is not supported'));
            } else {
                $window.navigator.geolocation.getCurrentPosition(function (position) {
                    resolve({
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    });
                }, reject(new Error('Geolocation is not returned.')));
            }
        })
    }

    return {GetLatAndLong}
})