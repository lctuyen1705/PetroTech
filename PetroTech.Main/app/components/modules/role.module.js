(function () {
    angular.module('petrotech.role', ['petrotech.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('role', {
            url: "/role",
            templateUrl: "app/components/roles/_roleView.html",
            controller: "_roleController"
        }).state('role-add', {
            url: "/role-add",
            templateUrl: "app/components/roles/roleAddView.html",
            controller: "roleAddController"
        }).state('role-edit', {
            url: "/role-edit",
            templateUrl: "app/components/roles/roleEditView.html",
            controller: "roleEditController"
        });
    }
})();