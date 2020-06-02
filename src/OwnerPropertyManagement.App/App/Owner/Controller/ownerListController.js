angular.module('ownerPropertyManagementApp').controller('ownerListController', [
  '$scope',
  '$state',
  'ownerService',
  '$uibModal',
  'masterTablesService',
  "toaster",
  function ($scope, $state, ownerService, $uibModal, masterTablesService, toaster) {
    const vm = this;
    vm.total = 0;
    vm.owners = [];
    vm.filter = { take: 5, page: 0 };
    vm.attributes = [
      { displayName: 'FirstName', attribute: 'firstName' },
      { displayName: 'Surname', attribute: 'surname' },
      { displayName: 'Nick', attribute: 'nick' },
      { displayName: 'Personal Phone', attribute: 'personalPhoneNumber' },
      { displayName: 'City', attribute: 'city' },
      { displayName: 'Country', attribute: 'country' },
      { displayName: 'Acctions', attribute: 'action' }
    ];

    vm.getAll = getAll;
    vm.addOrUpdate = addOrUpdate;
    vm.remove = remove;

    init()

    function init() {
      masterTablesService.getOwnerNameList().then(function (res) {
        vm.owners = res;
      })
      getAll();
    }

    function getAll() {
      ownerService.getAll(vm.filter).then(
        function (response) {
          vm.owners = response.items;
          vm.total = response.total;
          vm.numOfPages = [];
          for (let i = 0; i * vm.filter.take < vm.total; i++) {
            vm.numOfPages.push(i);
          }
        },
        function (error) {
          //todo:show the error
        }
      )
    }
    function addOrUpdate(id) {
      $uibModal.open({
        templateUrl: "/App/Owner/Views/ownerEdit.html",
        controller: "ownerEditController",
        replace: true,
        controllerAs: "ownerEditCtrl",
        resolve: {
          ownerService: function () {
            return ownerService;
          },
          id: function () {
            return id;
          }
        },
      }).result.then(function () {
        getAll();
      });
    }
    function remove(id) {
      if (vm.id !== 0) {
        ownerService.remove(id).then(function (response) {
          toaster.pop("success", "Owner removed successfully");
          $uibModalInstance.close();
        }, function (errors) {
          if(!errors){
            errors="Owner could not be removed";
          }
          toaster.pop("error", errors);
        });
      }
    }
  }
])
