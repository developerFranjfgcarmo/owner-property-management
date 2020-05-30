angular.module("ownerPropertyManagementApp",["ngRoute", "ui.router", "ui.bootstrap", "ngSanitize", "ui.bootstrap", "ngAnimate"])
angular.module("ownerPropertyManagementApp").config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $stateProvider.state("home",
    {
        url: "/home",
        controller: "homeController",
        controllerAs: "homeCtrl",
        templateUrl: "/App/home/home.html"
    })/*.state("owner",
    {
        url: "/owner",
        controller: "ownerController",
        controllerAs: "ownerCtrl",
        templateUrl: "/App/owner/ownerList.html"
    })*/;
    $locationProvider.html5Mode(true);
    $urlRouterProvider.otherwise("/home");
});