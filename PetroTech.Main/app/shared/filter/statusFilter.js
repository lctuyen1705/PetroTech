(function (app) {
    app.filter('statusUserFilter', function () {
        return function (input) {
            if (input == 'A') {
                return 'Active';
            }
            if (input == 'I') {
                return 'Inactive';
            }
        }
    });

    app.filter('statusFilter', function () {
        return function (input) {
            if (input) {
                return 'Yes';
            } else {
                return 'No';
            }
        }
    });

    app.filter('departmentFilter', function () {
        return function (input) {
            if (input == 'KD') {
                return 'Kinh Doanh';
            }
            if (input == 'HC') {
                return 'Hành Chính';
            }
        }
    });

})(angular.module('petrotech.common'));