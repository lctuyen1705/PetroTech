(function () {
    angular.module('petrotech.user', ['petrotech.common']).config(config);

    config.$inject = ['$stateProvider', '$ocLazyLoadProvider'];

    function config($stateProvider, $ocLazyLoadProvider) {

        $stateProvider.state('user', {
            url: "/user",
            templateUrl: "app/components/users/_userView.html",
            controller: "_userController",
            resolve: {
                user: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        serie: true,
                        files: [
                            'app/components/users/_userController.js'
                        ]
                    });
                }]
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

        $ocLazyLoadProvider.config({
            modules: [{
                name: 'user',
                files: [
                    'app/components/users/_userController.js'
                ],
            }],
        });
    }
})();