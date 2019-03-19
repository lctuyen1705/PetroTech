(function (app) {

    app.controller('userAddController', userAddController);

    userAddController.$inject = ['$scope', 'apiservice', 'notificationService', '$state'];

    function userAddController($scope, apiservice, notificationService, $state) {

        $scope.user = {
            UserName: null,
            FullName: null,
            Address: null,
            Email: null,
            City: null,
            DOB: null,
            Area: null,
            RoleId: null,
            Status: null,
            Department: null,
            Functions: []
        };

        $scope.status = {
            statusId: "A",
            statusName: "Active"
        };
        $scope.statusList = [
            { 'statusId': 'A', 'statusName': 'Active' },
            { 'statusId': 'I', 'statusName': 'Inactive' }
        ];

        $scope.area = {
            areaId: null,
            areaName: null,
            typeAheadFlag: false,
            readonly: true
        };
        $scope.areas = [
            { 'areaId': 'North', 'areaName': 'Chi nhánh Hà Nội' },
            { 'areaId': 'Central', 'areaName': 'Chi nhánh Đà Nẵng' },
            { 'areaId': 'HCMC', 'areaName': 'Chi nhánh Hồ Chí Minh' },
            { 'areaId': 'Mekong', 'areaName': 'Chi nhánh Cần Thơ' }
        ];

        $scope.department = {
            departmentId: null,
            departmentName: null,
            typeAheadFlag: false,
            readonly: true
        };
        $scope.departments = [
            { 'departmentId': 'TC-KT', 'departmentName': 'Phòng Tài Chính Kế Toán' },
            { 'departmentId': 'HC-NS', 'departmentName': 'Phòng Hành Chính Nhân Sự' },
            { 'departmentId': 'PTHT-KD', 'departmentName': 'Phòng Phân tích và Hỗ trợ Kinh Doanh' },
            { 'departmentId': 'KH-GH', 'departmentName': 'Bộ phận Kho và Giao Hàng' },
            { 'departmentId': 'KD-DA', 'departmentName': 'Phòng Kinh Doanh Dự Án' },
            { 'departmentId': 'KD-IT', 'departmentName': 'Phòng Kinh Doanh IT' }
        ];

        $scope.client = {
            firstName: null,
            typeAheadFlag: false,
            readonly: true
        };
        $scope.clients = [
            { 'firstName': 'An Giang' },
            { 'firstNamefirstName': 'Bà Rịa-Vũng Tàu' },
            { 'firstName': 'Bạc Liêu' },
            { 'firstName': 'Bắc Kạn' },
            { 'firstName': 'Bắc Giang' },
            { 'firstName': 'Bắc Ninh' },
            { 'firstName': 'Bến Tre' },
            { 'firstName': 'Bình Dương' },
            { 'firstName': 'Bình Định' },
            { 'firstName': 'Bình Phước' },
            { 'firstName': 'Bình Thuận' },
            { 'firstName': 'Cà Mau' },
            { 'firstName': 'Cao Bằng' },
            { 'firstName': 'Cần Thơ' },
            { 'firstName': 'Đà Nẵng' },
            { 'firstName': 'Đắk Lắk' },
            { 'firstName': 'Đắk Nông' },
            { 'firstName': 'Điện Biên' },
            { 'firstName': 'Đồng Nai' },
            { 'firstName': 'Đồng Tháp' },
            { 'firstName': 'Gia Lai' },
            { 'firstName': 'Hà Giang' },
            { 'firstName': 'Hà Nam' },
            { 'firstName': 'Hà Nội' },
            { 'firstName': 'Hà Tây' },
            { 'firstName': 'Hà Tĩnh' },
            { 'firstName': 'Hải Dương' },
            { 'firstName': 'Hải Phòng' },
            { 'firstName': 'Hòa Bình' },
            { 'firstName': 'Hồ Chí Minh' },
            { 'firstName': 'Hậu Giang' },
            { 'firstName': 'Hưng Yên' },
            { 'firstName': 'Khánh Hòa' },
            { 'firstName': 'Kiên Giang' },
            { 'firstName': 'Kon Tum' },
            { 'firstName': 'Lai Châu' },
            { 'firstName': 'Lào Cai' },
            { 'firstName': 'Lạng Sơn' },
            { 'firstName': 'Lâm Đồng' },
            { 'firstName': 'Long An' },
            { 'firstName': 'Nam Định' },
            { 'firstName': 'Nghệ An' },
            { 'firstName': 'Ninh Bình' },
            { 'firstName': 'Ninh Thuận' },
            { 'firstName': 'Phú Thọ' },
            { 'firstName': 'Phú Yên' },
            { 'firstName': 'Quảng Bình' },
            { 'firstName': 'Quảng Nam' },
            { 'firstName': 'Quảng Ngãi' },
            { 'firstName': 'Quảng Ninh' },
            { 'firstName': 'Quảng Trị' },
            { 'firstName': 'Sóc Trăng' },
            { 'firstName': 'Sơn La' },
            { 'firstName': 'Tây Ninh' },
            { 'firstName': 'Thái Bình' },
            { 'firstName': 'Thái Nguyên' },
            { 'firstName': 'Thanh Hóa' },
            { 'firstName': 'Thừa Thiên - Huế' },
            { 'firstName': 'Tiền Giang' },
            { 'firstName': 'Trà Vinh' },
            { 'firstName': 'Tuyên Quang' },
            { 'firstName': 'Vĩnh Long' },
            { 'firstName': 'Vĩnh Phúc' },
            { 'firstName': 'Yên Bái' }
        ];

        $scope.role = {
            RoleId: null,
            RoleName: null
        };
        $scope.roles = [];

        $scope.funcs = [];

        $scope.selectTypeAhead = function ($item) {
            $scope.client.firstName = $item.firstName;
            $scope.client.typeAheadFlag = true;
        };
        $scope.$watch('client.firstName', function (newVal, oldVal) {
            if ($scope.client.typeAheadFlag) {
                $scope.client.typeAheadFlag = false;
            } else {

            }

        });

        apiservice.get('api/user/getallinfo', null, function (result) {
            $scope.roles = result.data.RoleModels;
            $scope.funcs = result.data.FuncModels;
        }, function () {

        });

        $scope.AddNewUser = function () {
            apiservice.post('api/user/add', $scope.user,
                function (result) {
                    notificationService.displaySuccess(result.mess);
                    $state.go('user');
                }, function (error) {
                    notificationService.displayError(error.mess);
                });
        };

        $scope.loaderStyle = 'none';
        $scope.loaderCan = 'none';
        $scope.loaderCannot = 'none'; 
        $scope.mess = '';


        $scope.validateUserName = function () {
            apiservice.get('api/user/checkUser?userName=' + $scope.user.UserName, null, function (result) {             
                if (result.data) {
                    $scope.loaderCannot = 'block';
                    $scope.loaderCan = 'none';
                } else {
                    $scope.loaderCannot = 'none';
                    $scope.loaderCan = 'block';
                }
            }, function () {

            });
        };

        $scope.isChecked = function (FunctionId) {
            var match = false;
            for (var i = 0; i < $scope.user.Functions.length; i++) {
                if ($scope.user.Functions[i].FunctionId == FunctionId) {
                    match = true;
                }
            }
            return match;
        };

        $scope.sync = function (bool, fu) {
            if (bool) {
                // add item
                $scope.user.Functions.push(fu);
            } else {
                // remove item
                for (var i = 0; i < $scope.user.Functions.length; i++) {
                    if ($scope.user.Functions[i].FunctionId == fu.FunctionId) {
                        $scope.user.Functions.splice(i, 1);
                    }
                }
            }
        };

        apiservice.get('api/user/amazon', null, function (result) {
            
        }, function () {

        });
    };

})(angular.module('petrotech.user'));
