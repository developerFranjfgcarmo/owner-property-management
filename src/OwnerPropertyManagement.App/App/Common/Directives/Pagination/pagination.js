angular.module("ClcWorldApp").directive("clcPagination", function () {
    return {
        restrict: "E",
        replace: true,
        scope: {
            total: "@",
            filter: "=",
            numOfPages: "=",
            getAll: "&"
        },
        templateUrl: function (elem, attrs) {
            return "/App/Common/Directives/Pagination/pagination.html";
        },
        link: function (scope, element, attrs) {
            scope.turnPage = turnPage;
            function turnPage(index, last) {

                if (index < 0) {
                    index = 0;
                }

                if (last) {
                    if (index % 1 == 0) {
                        index--;
                    }
                }
                scope.filter.page = Math.trunc(index);

                scope.getAll();
            }
        }
    };
});