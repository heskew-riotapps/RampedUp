'use strict';
angular.module('app')
    .service('authService', ['$http', '$q', '$location',
    function ($http, $q, $location) {
    var self = this;
    this.isAdmin = false;
    this.isInternal = false;
    this.isCustomer = false;
    this.userName = "";
    this.userId = "";

    this.getCurrent = function () {
        console.log("getCurrent called");
        var deferred = $q.defer();
        var url = '/api/account/GetCurrent';
        $http({ method: 'POST', url: url }).
         success(function (data, status, headers, config) {
             self.isAdmin = data.isAdmin;
             self.isInternal = data.isInternal;
             self.isCustomer = data.isCustomer;
             self.userName = data.name;
             self.userId = data.id;
             deferred.resolve(data);
             console.log("getCurrent success");

         }).
         error(function (data, status, headers, config) {
             if (status != 401 && status != 403) {
                 alert(data.message);
             }
             console.log("getCurrent failed");
             deferred.reject(data.message);

         });
        return deferred.promise;
    };

    this.saveRegistration = function (user) {

        //_logOut();

        return $http.post('/api/user/register', user).then(function (response) {
            return response;
        });

    };

    this.authenticationCheck = function () {
        console.log("authenticationCheck called");
        var deferred = $q.defer();
        var url = '/api/auth/authenticationCheck';
        $http({ method: 'POST', url: url }).
         success(function (data, status, headers, config) {
             deferred.resolve(data);
             console.log("authenticationCheck success");

         }).
         error(function (data, status, headers, config) {
             if (status != 401 && status != 403) {
                 alert(data.message);
             }
             console.log("authenticationCheck failed");
             deferred.reject(data.message);

         });
        return deferred.promise;
    };

    this.authorizationCheck = function (role) {
        console.log("authorizationCheck called");
        var data = {};
        data.role = role;
        var deferred = $q.defer();
        var url = '/api/auth/AuthorizationCheck';
        $http({ method: 'POST', data: data, url: url }).
         success(function (data, status, headers, config) {
             deferred.resolve(data);
             console.log("authorizationCheck success");

         }).
         error(function (data, status, headers, config) {
             if (status != 401 && status != 403) {
                 alert(data.message);
             }
             console.log("authorizationCheck failed");
             deferred.reject(data.message);

         });
        return deferred.promise;
    };

}]);