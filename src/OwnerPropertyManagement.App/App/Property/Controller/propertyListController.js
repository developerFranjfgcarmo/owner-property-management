angular.module('ownerPropertyManagementApp').controller('propertyListController', [
  '$scope',
  '$state',
  'propertyService',
  '$uibModal',
  'masterTablesService',
  function ($scope, $state, propertyService, $uibModal, masterTablesService) {
    const vm = this;
    vm.properties = [];
    vm.total = 0;
    vm.ownerId=null;
    vm.owners = [];
    vm.filter = { take: 5, page: 1 };
    vm.attributes = [      
      { displayName: 'Property', attribute: 'name' },
      { displayName: 'Owner', attribute: 'owner' },
      { displayName: 'Town', attribute: 'town' },
      { displayName: 'Zone', attribute: 'zone' },
      { displayName: 'DistanceAirport', attribute: 'distanceAirport' },
      { displayName: 'DistanceBeach', attribute: 'distanceBeach' },
      { displayName: 'active', attribute: 'active' },
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
      propertyService.getAll(vm.filter).then(
        function (response) {
          vm.properties = response.items;
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
        templateUrl: "/App/Property/Views/propertyEdit.html",
        controller: "propertyEditController",
        replace: true,
        controllerAs: "propertyEditCtrl",           
        resolve: {            
            propertyService: function() {
              return propertyService;
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
