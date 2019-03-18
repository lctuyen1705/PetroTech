(function () {
    angular.module('petrotech.dashboard', ['petrotech.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('dashboard', {
            url: "/admin",
            templateUrl: "app/components/dashboard/_dashboardView.html",
            controller: "dashboardController.js"
        });
    }
})();