'use strict';
app.controller('signinController', ['$scope', '$rootScope', 'authService', '$translate',
    function ($scope, $rootScope, authService, $translate) {

        $scope.user = {};
        $scope.emailPlaceholder = "";
        $scope.passwordPlaceholder = "";

        $translate(['Views.Signin.Placeholders.Email',
                    'Views.Signin.Placeholders.Password']).then(function (translations) {
                        $scope.emailPlaceholder = translations['Views.Signin.Placeholders.Email'];
                        $scope.passwordPlaceholder = translations['Views.Signin.Placeholders.Password'];
                    });


    }]);