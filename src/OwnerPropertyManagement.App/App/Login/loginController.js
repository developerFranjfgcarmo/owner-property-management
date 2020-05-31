angular.module('ownerPropertyManagementApp').controller('loginController', [
  '$scope',
  '$state',
  'authService',
  'localStorageService',
  function ($scope, $state, authService, localStorageService) {
    var vm = this
    vm.user = { username: '', password: '' }
    vm.error = ''

    vm.canLogin = canLogin
    vm.login = login

    function canLogin () {
      return vm.user.username.length > 0 && vm.user.password.length > 0
    }

    function login () {
      authService.login(vm.user).then(
        function (response) {
          localStorageService.set('authorizationData', response.data.token)
          $state.go('home')
        },
        function (e) {
          vm.error = 'User or password incorrect.'
        }
      )
    }
  }
])
