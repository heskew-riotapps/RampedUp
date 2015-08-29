'use strict';
app.factory('authInterceptorService', ['$q', '$location', '$localStorage', '$rootScope', '$injector',
    function ($q, $location, $localStorage, $rootScope, $injector) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {
        config.headers = config.headers || {};

        if (angular.isDefined($localStorage.authData)) {
            var authData = $localStorage.authData;
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        debugger;
        if (rejection.status === 401 || rejection.status === 403) {
            //    if ($location.path() != '/#/signin') { $rootScope.redirect = $location.path(); }
            if ($injector.get('$state').current.name != 'signin') {
                $injector.get('$state').go('signin'); //vs transitionTo
            }
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);