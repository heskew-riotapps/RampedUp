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
    ['$rootScope', '$state', '$stateParams',
      function ($rootScope, $state, $stateParams) {
          $rootScope.$state = $state;
          $rootScope.$stateParams = $stateParams;
      }
    ]
  )
  .config(
    ['$stateProvider', '$urlRouterProvider',
      function ($stateProvider, $urlRouterProvider) {
          $urlRouterProvider
            .otherwise('/app/home');
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
                    //'kickstarter': {
                    //    templateUrl: 'api/views/a/samples/kickstarter'
                    //}
                }
            })
              .state('app.home', {
                  url: '/home',
                  templateUrl: 'api/views/a/samples/streamline'

              })

         .state('app.kickstarter', {
             url: '/sample/kickstarter',
             templateUrl: 'api/views/a/samples/kickstarter',
             controller: 'kickstarterController'
         })
          .state('app.gameplan', {
              url: '/sample/gameplan',
              templateUrl: 'api/views/a/samples/gameplan',
              controller: 'gamePlanController'
          })
          .state('app.winvault', {
              url: '/sample/winvault',
              templateUrl: 'api/views/a/samples/winvault',
              controller: 'winVaultController'
          })
            ////.state('main.gameplan', {
            ////    url: '/gameplan',
            ////    templateUrl: 'api/views/a/app/gameplan'

            ////})
            ////.state('main.winvault', {
            ////    url: '/winvault',
            ////    templateUrl: 'api/views/a/app/winvault'

            ////})


      }
    ]
  );