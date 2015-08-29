'use strict';
app.controller('signinController', ['$scope', '$rootScope', 'authService', '$translate', 'messageService', '$state',
    function ($scope, $rootScope, authService, $translate, messageService, $state) {

        $scope.user = {};
        $scope.emailPlaceholder = "";
        $scope.passwordPlaceholder = "";
        $scope.saving = false;

        $translate(['Views.Signin.Placeholders.Email',
                    'Views.Signin.Placeholders.Password']).then(function (translations) {
                        $scope.emailPlaceholder = translations['Views.Signin.Placeholders.Email'];
                        $scope.passwordPlaceholder = translations['Views.Signin.Placeholders.Password'];
                    });

        $scope.onSigninClick = function () {
            if ($scope.saving == false) {
                $scope.saving = true;
                authService.login($scope.user).then(function (response) {
                    $rootScope.$broadcast('login.success');
                    $scope.saving = false;
                    $scope.loginInProcess = false;
                    debugger;

                    var redirect = $rootScope.redirect == "" ? "/ui/search" : $rootScope.redirect;
                    $rootScope.redirect = "";
                  //  $location.path(redirect);
                    $state.go('dashboard')
                },
                function (err) {
                    $scope.saving = false;
                    $scope.loginInProcess = false;

                    messageService.danger(err.error_description);
                });
   
            }
        };

    }]);