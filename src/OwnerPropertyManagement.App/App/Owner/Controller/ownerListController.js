angular.module('ownerPropertyManagementApp').controller('ownerListController', [
    '$scope',
    '$state',
    'ownerService',
    '$uibModal',
    'masterTablesService',
    function ($scope, $state, ownerService, $uibModal, masterTablesService) {
      const vm = this;
      vm.total = 0;
      vm.owners = [];
      vm.filter = { take: 5, page: 1 };
      vm.attributes = [      
        { displayName: 'FirstName', attribute: 'firstName' },
        { displayName: 'Surname', attribute: 'surname' },
        { displayName: 'Nick', attribute: 'nick' },
        { displayName: 'Personal Phone', attribute: 'personalPhoneNumber' },
        { displayName: 'City', attribute: 'city' },
        { displayName: 'Country', attribute: 'country' },
        { displayName: 'Edit', attribute: 'action' }
      ];
      vm.getAll = getAll;
      vm.addOrUpdate = addOrUpdate;
  
      init()
  
      function init () {
        masterTablesService.getOwnerNameList().then(function (res) {
          vm.owners = res;
        })
        getAll();
      }
  
      function getAll () {
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
      function addOrUpdate(id){
        $uibModal.open({
          templateUrl: "/App/owner/Views/ownerEdit.html",
          controller: "ownerEditController",
          replace: true,
          controllerAs: "ownerEditCtrl",           
          resolve: {            
              ownerService: function() {
                return ownerService;
            },
            masterTablesService: function() {
                return masterTablesService;
            },
            id: function () {
              return id;
          }
          },        
      }).result.then(function() {
          getAll();
      });
      }
    }
  ])
  