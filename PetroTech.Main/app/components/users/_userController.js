(function (app) {
    app.controller('_userController', _userController);

    _userController.$inject = ['$scope', 'apiservice', 'notificationService'];

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

    function _userController($scope, apiservice, notificationService) {

        $scope.users = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.pageSize = 1;
        $scope.getListUsers = getListUsers;
        $scope.keyword = '';
        $scope.search = search;

        $scope.item = 1;
        $scope.nums = [1, 10, 50];

        function search() {
            getListUsers();
        }

        function getListUsers(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: $scope.item
                }
            };

            apiservice.get('api/user/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning(result.data.Mess);
                }
                $scope.users = result.data.Items;
                $scope.page = result.data.Page;
                $scope.totalCount = result.data.TotalCount;
                $scope.pagesCount = result.data.TotalPage;
            }, function () {

            });
        }
        $scope.getListUsers();
    }

})(angular.module('petrotech.user'));