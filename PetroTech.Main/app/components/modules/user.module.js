(function () {
    angular.module('petrotech.user', ['petrotech.common']).config(config);

    config.$inject = ['$stateProvider', '$ocLazyLoadProvider'];

    function config($stateProvider, $ocLazyLoadProvider) {

        $ocLazyLoadProvider.config({
            modules: [{
                name: 'user',
                files: [
                    'app/components/users/_userController.js'
                ],
            }],
        });

        $stateProvider.state('user', {
            url: "/user",
            templateUrl: "app/components/users/_userView.html",
            controller: "_userController",
            resolve: {
                loadDependencies: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load('user');
                }],
            }
        }).state('user-add', {
            url: "/user-add",
            templateUrl: "app/components/users/userAddView.html",
            controller: "userAddController"
        }).state('user-edit', {
            url: "/user-edit/:id",
            templateUrl: "app/components/users/userEditView.html",
            controller: "userEditController"
        });  
    }
})();