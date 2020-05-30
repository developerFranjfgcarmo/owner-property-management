"use strict";
angular.module("ClcWorldApp").factory("masterTablesService",
    [
        "$q", "$http", function ($q, $http) {
            return {
                getCarBrand: getCarBrand,
                getFranchisee: getFranchisee,
            };

            function getCarBrand(filter) {
                var deferred = $q.defer();
                $http({
                    method: "GET",
                    url: clcw.apiService + clcw.masterTablesUrl + "carBrand"
                }).then(function (response) {
                    deferred.resolve(response.data.result);
                }, function (response) {
                    deferred.reject(response.data.validationErrors);
                });
                return deferred.promise;
            }

            function getFranchisee(filter) {
                var deferred = $q.defer();
                $http({
                    method: "GET",
                    url: clcw.apiService + clcw.masterTablesUrl + "franchisees"
                }).then(function (response) {
                    deferred.resolve(response.data.result);
                }, function (response) {
                    deferred.reject(response.data.validationErrors);
                });
                return deferred.promise;
            }
        }
    ]);