'use strict';
app.controller('addOpportunityController', ['$scope', '$rootScope', '$http', '$translate', 'messageService',
    function ($scope, $rootScope, $http, $translate, messageService) {

    //authService.authorizationCheck("Admin,Developer,Internal").then(function (data) {
         $scope.authorized = true;
    //});
    
    $scope.saving = false;

 
    $scope.model = {};


    $scope.onSaveClick = function () {

        if ($scope.saving == false) {
            $scope.saving = true;

            $http({ method: 'POST', data: $scope.model, url: '/api/win/addopportunity' }).
               success(function (data, status, headers, config) {
                   debugger;
                   $scope.saving = false;
                   $translate('Views.AddOpportunity.Messages.SaveOK', { "opportunityId": data.id }).then(function (translation) {
                       messageService.success(translation);
                       init();
                   });
               }).
               error(function (data, status, headers, config) {
                   debugger;
                   $translate('General.ErrorPrepend').then(function (translation) {
                       messageService.danger(translation + data.message);
                   });
                   $scope.saving = false;
               });
        }
    };

    var init = function () {
        $scope.model.competitor = "";
        $scope.model.industry = "";
    }

}]);