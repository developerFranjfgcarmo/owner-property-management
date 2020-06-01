angular
  .module('ownerPropertyManagementApp')
  .controller('ownerEditController', [
    '$scope',
    'ownerService',
    'id',
    "$uibModalInstance",
    function ($scope, ownerService, id, $uibModalInstance) {
      var vm = this;
      vm.id = id;
      vm.owner = {};      
      vm.currentModel = {};

      vm.get = get;
      vm.dismiss = dismiss;
      vm.modelIsValid = modelIsValid; 
      vm.save = save;
      init();

      function init () {       
        get(vm.id);
      }

      function get (id) {
        if (id === 0) {
          return;
        }
        ownerService.get(id).then(
          function (response) {
            vm.owner = response;
            vm.currentModel = angular.copy(response);
          }/* ,
          function (error) {
            //todo:show the error
          } */
        )
      }    

      function dismiss() {
        $uibModalInstance.dismiss();
      }

      function modelIsValid() {
          return vm.frm.$valid && !angular.equals(vm.currentModel, vm.owner);
      } 
      function save() {
        if (vm.id === 0) {
          ownerService.add(vm.owner).then(function (response) {
            vm.owner = response;
            vm.currentModel = angular.copy(response);
            $uibModalInstance.close();
          }, function (errors) {
              vm.errors = errors;
          });
      } else {
        ownerService.update(vm.owner).then(function (response) {
              vm.owner = response;
              vm.currentModel = angular.copy(response);
              $uibModalInstance.close();
          }, function (errors) {
              vm.errors = errors;
          });
      }      
      } 
      
    }
  ])
