angular.module('ownerPropertyManagementApp').factory('authService', [
  '$http',
  function ($http) {  
    var login = function (user) {
      return $http.post(opm.apiService + opm.loginUrl, user)
    }

    return {
      login: login
    }
  }
]);
