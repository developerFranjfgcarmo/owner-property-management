angular
  .module('ownerPropertyManagementApp')
  .controller('propertyEditController', [
    '$scope',
    'propertyService',
    'masterTablesService',
    'id',
    "$uibModalInstance",
    "toaster",
    function ($scope, propertyService, masterTablesService, id, $uibModalInstance,toaster) {
      var vm = this;
      vm.id = id;
      vm.property = {};
      vm.facilities = [];
      vm.towns = [];
      vm.owners = [];
      vm.currentModel = {};
      vm.errors=undefined;
      vm.get = get;
      vm.dismiss = dismiss;
      vm.modelIsValid = modelIsValid; 
      vm.save = save;
      init();

      function init () {
        masterTablesService.getTowns().then(function (res) {
          vm.towns = res;
        });
        masterTablesService.getFacilities().then(function (res) {
          vm.facilities = res;
        });
        masterTablesService.getOwnerNameList().then(function (res) {
          vm.owners = res;
        })
        get(vm.id);
      }

      function get (id) {
        if (id === 0) {
          return;
        }
        propertyService.get(id).then(
          function (response) {
            vm.property = response;
            vm.currentModel = angular.copy(response);
          }
        )
      }    

      function dismiss() {
        $uibModalInstance.dismiss();
      }

      function modelIsValid() {
          return vm.frm.$valid && !angular.equals(vm.currentModel, vm.property);
      } 
      function save() {
        if (vm.id === 0) {
          propertyService.add(vm.property).then(function (response) {
            vm.property = response;
            vm.currentModel = angular.copy(response);
            toaster.pop("success", "Property created successfully");
            $uibModalInstance.close();            
          }, function (errors) {
              vm.errors = errors;
          });
      } else {
        propertyService.update(vm.property).then(function (response) {
              vm.property = response;
              vm.currentModel = angular.copy(response);
              toaster.pop("success", "Property updated successfully");
              $uibModalInstance.close();
          }, function (errors) {
              vm.errors = errors;
          });
      }      
      } 
      
    }
  ])
