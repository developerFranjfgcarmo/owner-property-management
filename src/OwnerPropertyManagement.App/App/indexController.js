angular.module('ownerPropertyManagementApp').controller('indexController', [
  '$scope',
  '$state',
  'localStorageService',
  function ($scope, $state, localStorageService) {
    var vm = this

    vm.logOut = logOut;
    vm.isAuth = isAuth;
    vm.goHome = goHome;

    function logOut() {
      localStorageService.remove('authorizationData');
      $state.go('login');
    }

    function isAuth() {
      return localStorageService.get('authorizationData');
    }
    function goHome() {
      $state.go('home');
    }
  }
])
