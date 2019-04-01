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
        $scope.pagesCount = 0;
        $scope.pageSize = 5;
        $scope.keyword = '';
        $scope.usernameVal = '';
        $scope.areaVal = '';
        $scope.departmentVal = '';
        $scope.statusVal = '';

        $scope.param = {
            UserName: null,
            Area: null,
            Department: null,
            Status: null
        };

        $scope.item = 5;
        $scope.nums = [5, 10, 50];

        $scope.status = {
            statusId: '',
            statusName: 'Tất cả'
        };
        $scope.statusList = [
            { 'statusId': '', 'statusName': 'Tất cả' },
            { 'statusId': 'A', 'statusName': 'Active' },
            { 'statusId': 'I', 'statusName': 'Inactive' }
        ];

        $scope.area = {
            areaId: '',
            areaName: 'Tất cả'
        };
        $scope.areas = [
            { 'areaId': '', 'areaName': 'Tất cả' },
            { 'areaId': 'North', 'areaName': 'Chi nhánh Hà Nội' },
            { 'areaId': 'Central', 'areaName': 'Chi nhánh Đà Nẵng' },
            { 'areaId': 'HCMC', 'areaName': 'Chi nhánh Hồ Chí Minh' },
            { 'areaId': 'Mekong', 'areaName': 'Chi nhánh Cần Thơ' }
        ];

        $scope.department = {
            departmentId: '',
            departmentName: 'Tất cả'
        };
        $scope.departments = [
            { 'departmentId': '', 'departmentName': 'Tất cả' },
            { 'departmentId': 'KD', 'departmentName': 'Phòng Kinh Doanh' },
            { 'departmentId': 'HC', 'departmentName': 'Phòng Hành Chính' },
        ];

        $scope.SearchUser = function () {
            $scope.page = $scope.page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: $scope.page,
                    pageSize: $scope.item,
                    usernameVal: $scope.usernameVal,
                    areaVal: $scope.areaVal,
                    departmentVal: $scope.departmentVal,
                    statusVal: $scope.statusVal,
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

    }

})(angular.module('petrotech.user'));