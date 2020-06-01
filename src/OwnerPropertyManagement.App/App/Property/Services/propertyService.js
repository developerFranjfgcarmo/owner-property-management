angular.module('ownerPropertyManagementApp').factory('propertyService', [
  '$http',
  '$q',
  function ($http, $q) {
    return {
      getAll: getAll,
      get: get,
      add: add,
      update: update,
      remove: remove
    }

    function getAll (filter) {
      var deferred = $q.defer()
      $http({
        method: 'GET',
        url: opm.apiService + opm.properyUrl,
        params: filter
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

    function get (id) {
      var deferred = $q.defer()
      $http({
        method: 'GET',
        url: opm.apiService + opm.properyUrl + id
      }).then(
        function (response) {
          deferred.resolve(response.data)
        },
        function (response) {
          deferred.reject(response.data)
        }
      );
      return deferred.promise;
    }

    function add (property) {
      var deferred = $q.defer()
      $http({
        method: 'POST',
        url: opm.apiService + opm.properyUrl,
        data: property
      }).then(
        function (response) {
          deferred.resolve(response.data)
        },
        function (response) {
          deferred.reject(response.data.errors)
        }
      );
      return deferred.promise;
    }

    function update (property) {
      var deferred = $q.defer()
      $http({
        method: 'PUT',
        url: opm.apiService + opm.properyUrl,
        data: property
      }).then(
        function (response) {
          deferred.resolve(response.data)
        },
        function (response) {
          deferred.reject(response.data.errors)
        }
      );
      return deferred.promise;
    }

    function remove (id) {
      var deferred = $q.defer()

      $http({
        method: 'DELETE',
        url: opm.apiService + opm.properyUrl + id
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
