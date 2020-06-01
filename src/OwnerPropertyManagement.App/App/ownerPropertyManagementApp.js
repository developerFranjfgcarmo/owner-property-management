angular.module('ownerPropertyManagementApp', [
  'ngRoute',
  'ui.router',
  'ui.bootstrap',
  'ngSanitize',
  'ui.bootstrap',
  'ngAnimate',
  'LocalStorageModule',
  "toaster",
  "angular-loading-bar"
])
angular
  .module('ownerPropertyManagementApp')
  .config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider
      .state('login', {
        url: '/login',
        templateUrl: '/App/Login/login.html',
        controller: 'loginController',
        controllerAs: 'loginCtrl'
      })
      .state('home', {
        url: '/home',
        controller: 'homeController',
        controllerAs: 'homeCtrl',
        templateUrl: '/App/home/home.html'
      })
      .state('properties', {
        url: '/properties',
        controller: 'propertyListController',
        controllerAs: 'propertyListCtrl',
        templateUrl: '/App/property/Views/propertyList.html'
      }).state('owners', {
        url: '/owners',
        controller: 'ownerListController',
        controllerAs: 'ownerListCtrl',
        templateUrl: '/App/Owner/Views/ownerList.html'
      })
    $locationProvider.html5Mode(true)
    $urlRouterProvider.otherwise('/home')
  })
  .factory('authHttpResponseInterceptor', [
    '$q',
    '$injector',
    'localStorageService',
    function ($q, $injector, localStorageService) {
      return {
        request: function (config) {
          config.headers = config.headers || {}

          var token = localStorageService.get('authorizationData')
          if (token) {
            config.headers.Authorization = 'Bearer ' + token
          }

          return config
        },

        responseError: function (rejection) {
          if (rejection.status === 401) {
            console.log('Response Error 401', rejection)
            localStorageService.remove('authorizationData')
            var $state = $injector.get('$state')
            $state.go('login')
          }
          if (rejection.status === 500) {
            toaster.pop("error", "Error", "Internal Server Error");
          }
          return $q.reject(rejection)
        }
      }
    }
  ])
  .config([
    '$httpProvider',
    function ($httpProvider) {
      //Http Intercpetor to check auth failures for xhr requests
      $httpProvider.interceptors.push('authHttpResponseInterceptor')
    }
  ])
  angular.module("ownerPropertyManagementApp").config(function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeBar = true;
    cfpLoadingBarProvider.includeSpinner = true;
    cfpLoadingBarProvider.latencyThreshold = 200;
});
