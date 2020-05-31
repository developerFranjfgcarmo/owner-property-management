'use strict'
angular.module('ownerPropertyManagementApp').factory('masterTablesService', [
  '$q',
  '$http',
  function ($q, $http) {
    return {
      getTowns: getTowns,
      getFacilities: getFacilities
    }

    function getTowns (filter) {
      var deferred = $q.defer()
      $http({
        method: 'GET',
        url: opm.apiService + opm.masterTablesUrl + 'towns'
      }).then(
        function (response) {
          deferred.resolve(response.data)
        },
        function (response) {
          deferred.reject(response.data)
        }
      )
      return deferred.promise
    }

    function getFacilities (filter) {
      var deferred = $q.defer()
      $http({
        method: 'GET',
        url: opm.apiService + opm.masterTablesUrl + 'facilities'
      }).then(
        function (response) {
          deferred.resolve(response.data)
        },
        function (response) {
          deferred.reject(response.data)
        }
      )
      return deferred.promise
    }
  }
])
