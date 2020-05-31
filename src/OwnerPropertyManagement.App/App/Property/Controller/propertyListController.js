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
    vm.filter = { take: 5, page: 1 };
    vm.attributes = [
      { displayName: 'Id', attribute: 'id' },
      { displayName: 'Property', attribute: 'name' },
      { displayName: 'Owner', attribute: 'owner' },
      { displayName: 'Town', attribute: 'town' },
      { displayName: 'Zone', attribute: 'zone' },
      { displayName: 'DistanceAirport', attribute: 'distanceAirport' },
      { displayName: 'DistanceBeach', attribute: 'distanceBeach' },
      { displayName: 'DistanceBeach', attribute: 'active' }
    ];
    vm.getAll = getAll;
    vm.add = addOrUpdate;

    init()

    function init () {
      getAll();
    }

    function getAll () {
      propertyService.getAll(vm.filter).then(
        function (response) {
          vm.properties = response.item;
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
        bindToController: true,
        controllerAs: "propertyEditController",
        resolve: {
            $scope: function() {
                $scope.id = id;
                return $scope;
            },
            propertyService: function() {
              return propertyService;
          },
          masterTablesService: function() {
              return masterTablesService;
          }
        },        
    }).result.then(function(result) {
        getAll();
    });
    }
  }
])
