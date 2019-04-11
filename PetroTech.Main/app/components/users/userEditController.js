(function (app) {

    app.controller('userEditController', userEditController);

    userEditController.$inject = ['$scope', 'apiservice', 'notificationService', '$state', '$stateParams'];

    function userEditController($scope, apiservice, notificationService, $state, $stateParams) {

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
            PhoneNumber: null,
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
            { 'departmentId': 'KD', 'departmentName': 'Phòng Kinh Doanh' },
            { 'departmentId': 'HC', 'departmentName': 'Phòng Hành Chính' },
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

        apiservice.get('api/user/getbyuser/' + $stateParams.id, null, function (result) {
            $scope.user = result.data;
            $scope.user.Functions = result.data.Functions;
            $scope.user.DOB = new Date(result.data.DOB);
        }, function (error) {
            notificationService.displayError(error.data);
        });

        $scope.modelError = 'none';

        $scope.UpdateUser = function () {
            apiservice.put('api/user/update', $scope.user,
                function (result) {
                    if (result.data.IsProcess) {
                        notificationService.displaySuccess(result.data.Mess);
                        $state.go('user');
                    } else {
                        $scope.modelError = 'block';
                        notificationService.displayWarning(result.data.Mess);
                        $scope.listErrors = result.data.ListData;
                    }
                }, function (error) {
                    notificationService.displayError(error);
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
                $scope.user.Functions.push(fu);
            } else {
                for (var i = 0; i < $scope.user.Functions.length; i++) {
                    if ($scope.user.Functions[i].FunctionId == fu.FunctionId) {
                        $scope.user.Functions.splice(i, 1);
                    }
                }
            }
        };
    };

})(angular.module('petrotech.user'));
