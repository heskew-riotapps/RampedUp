'use strict';

/**
 * @ngdoc function
 * @name app.config:uiRouter
 * @description
 * # Config
 * Config for the router
 */
angular.module('app')
  .run(
    [           '$rootScope', '$state', '$stateParams',
      function ( $rootScope,   $state,   $stateParams ) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;
      }
    ]
  )
  .config(
    [          '$stateProvider', '$urlRouterProvider',
      function ( $stateProvider,   $urlRouterProvider ) {
        $urlRouterProvider
          .otherwise('/app/dashboard');
        $stateProvider
          .state('app', {
            abstract: true,
            url: '/app',
            views: {
              '': {
                  templateUrl: 'api/views/a/home/layout'
              },
              'aside': {
                  templateUrl: 'api/views/a/home/asidenavuikit'
              }
            }
          })
            .state('app.dashboard', {
              url: '/dashboard',
              templateUrl: 'api/views/a/home/dashboard'
             
            })

      }
    ]
  );