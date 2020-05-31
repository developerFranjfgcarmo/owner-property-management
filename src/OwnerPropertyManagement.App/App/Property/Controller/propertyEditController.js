angular
  .module('ownerPropertyManagementApp')
  .controller('propertyEditController', [
    '$scope',
    'propertyService',
    'masterTablesService',
    function ($scope, propertyService, masterTablesService) {
      const vm = this;
      vm.id = $scope.id;
      vm.property = {};
      vm.facilities = [];
      vm.towns = [];
      vm.get = get;

      init();

      function init () {
        masterTablesService.getTowns().then(function (res) {
          self.towns = res;
        })
        masterTablesService.getFacilities().then(function (res) {
          self.facilities = res;
        })
        get(vm.id);
      }

      function get (id) {
        if (id === 0) {
          return
        }
        propertyService.get(id).then(
          function (response) {
            vm.property = response;
          },
          function (error) {
            //todo:show the error
          }
        )
      }
    }
  ])
