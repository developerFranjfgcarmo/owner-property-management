"use strict";
angular.module("ownerPropertyManagementApp").controller("homeController", [
    "$scope", "$state",'localStorageService', function ($scope, $state,localStorageService) {
        var vm = this;
        init();
        function init(){
            if(!localStorageService.get("authorizationData")){
                $state.go('login');
            }
        }
    }
]);