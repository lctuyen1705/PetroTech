(function (app) {
    app.controller('roleAddController', roleAddController);

    roleAddController.$inject = ['$scope', 'apiservice', 'notificationService', 'Guid', '$state'];

    function roleAddController($scope, apiservice, notificationService, Guid, $state) {

        $scope.role = {
            RoleId: $scope.newGuid,
            RoleCode: null,
            RoleName: null
        };
        $scope.modelError = 'none';
        $scope.loader = 'none';
        $scope.newGuid = Guid.newGuid();

        $scope.validateRoleCode = function () {
            apiservice.get('api/role/checkrole?roleCode=' + $scope.role.RoleCode, null, function (result) {
                $scope.rsMess = result.data.Mess;
                $scope.loader = result.data.Data;
                $scope.rsClass = result.data.Class;
            }, function () {

            });
        };


        $scope.AddNewRole = function () {
            apiservice.post('api/role/add', $scope.role,
                function (result) {
                    if (result.data.IsProcess) {
                        notificationService.displaySuccess(result.data.Mess);
                        $state.go('role');
                    } else {
                        $scope.modelError = 'block';
                        notificationService.displayWarning(result.data.Mess);
                        $scope.listErrors = result.data.ListData;
                    }
                }, function (error) {
                    notificationService.displayError(error);
                });
        };
    }

})(angular.module('petrotech.role'));