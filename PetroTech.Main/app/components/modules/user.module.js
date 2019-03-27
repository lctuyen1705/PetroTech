(function () {
    angular.module('petrotech.user', ['petrotech.common']).config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {


        $stateProvider.state('user', {
            url: "/user",
            templateUrl: "app/components/users/_userView.html",
            controller: "_userController"
        }).state('user-add', {
            url: "/user-add",
            templateUrl: "app/components/users/userAddView.html",
            controller: "userAddController"
        }).state('user-edit', {
            url: "/user-edit",
            templateUrl: "app/components/users/userEditView.html",
            controller: "userEditController"
        });
    }
})();