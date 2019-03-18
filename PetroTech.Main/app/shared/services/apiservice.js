(function (app) {
    app.service('apiservice', apiservice);

    apiservice.$inject = ['$http'];

    function apiservice($http) {
        return {
            get: get,
            post: post
        }

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }

})(angular.module('petrotech.common'));