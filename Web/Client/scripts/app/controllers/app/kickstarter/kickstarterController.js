'use strict';
app.controller('kickstarterController', ['$scope', '$rootScope', '$location', 'authService',
    function ($scope, $rootScope, $location, authService) {

        authService.authorizationCheck("Admin,Developer,Internal").then(function (data) {
            $scope.authorized = true;
        });
 

}]);