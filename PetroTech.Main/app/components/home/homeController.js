(function (app) {
    app.run(['$rootScope', function ($rootScope) {
        $rootScope.lang = 'vn';
    }]);

    app.controller('homeController', homeController);

    function homeController($scope, $rootScope, $translate) {
        $scope.changeLanguage = function (key) {
            $rootScope.lang = key;
            $translate.use(key);
        };
    }
})(angular.module('petrotech'));