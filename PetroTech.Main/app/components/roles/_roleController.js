(function (app) {
    app.controller('_roleController', _roleController);

    _roleController.$inject = ['$scope', 'apiservice', 'notificationService', '$ngBootbox'];

    app.directive('myEnter', function () {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.myEnter);
                    });

                    event.preventDefault();
                }
            });
        };
    });

    function _roleController($scope, apiservice, notificationService, $ngBootbox) {

        $scope.roles = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 5;
        $scope.keyword = '';
        $scope.rolenameVal = '';

        $scope.item = 5;
        $scope.nums = [5, 10, 50];

        $scope.getListRoles = getListRoles;
        $scope.SearchRole = SearchRole;

        function SearchRole() {
            getListRoles();
        }

        function getListRoles(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.item,
                    rolenameVal: $scope.rolenameVal
                }
            };

            apiservice.get('api/role/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning(result.data.Mess);
                }
                $scope.roles = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPage;
            }, function () {

            });
        }

        $scope.deleteRole = deleteRole;

        function deleteRole(id) {
            $ngBootbox.confirm('Are you sure for delete this role?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiservice.del('api/role/del', config, function (result) {
                    if (result.data.IsProcess) {
                        notificationService.displaySuccess(result.data.Mess);
                        SearchRole();
                    } else {
                        notificationService.displayWarning(result.data.Mess);
                    }
                }, function (error) {
                    notificationService.displayError(error);
                })
            });
        }

        $scope.getListRoles();
    }

})(angular.module('petrotech.role'));