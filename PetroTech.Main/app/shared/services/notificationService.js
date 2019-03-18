(function (app) {
    app.factory('notificationService', notificationService);

    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };

        function displaySuccess(mess) {
            toastr.success(mess);
        }
        function displayError(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                })
            }
        }
        function displayWarning(mess) {
            toastr.warning(mess);
        }
        function displayInfo(mess) {
            toastr.info(mess);
        }

        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfo: displayInfo
        }
    }
})(angular.module('petrotech.common'));