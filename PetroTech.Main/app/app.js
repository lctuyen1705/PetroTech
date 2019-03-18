(function () {
    angular.module('petrotech',
        [
            'petrotech.common',
            'petrotech.role',
            'petrotech.user',
            'pascalprecht.translate',
        ]
    ).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$translateProvider'];

    function config($stateProvider, $urlRouterProvider, $translateProvider) {

        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "app/components/home/_homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');

        $translateProvider.translations('en', {
            STR_FOOTER_INFO: 'Copyright of PSD © 2019 developed by',

            STR_BUTTOM_ADD: 'Add New',
            STR_BUTTOM_DELETE: 'Delete',
            STR_BUTTOM_EDIT: 'Edit',
            STR_BUTTOM_EXPORT: 'Export',
            STR_BUTTOM_IMPORT: 'Import',
            STR_BUTTOM_BACK: 'Back',
            STR_BUTTOM_SAVE: 'Save',
            STR_BUTTOM_CLEAR: 'Clear',

            STR_STATUS_USER_A: 'Active',
            STR_STATUS_USER_I: 'InActive',

            STR_MANAGE_USER: 'Manage User',
            STR_MANAGE_LIST_USER: 'List Users',
            STR_MANAGE_USER_TABLE_TITLE_USERNAME: 'User Name',
            STR_MANAGE_USER_TABLE_TITLE_FULLNAME: 'Full Name',
            STR_MANAGE_USER_TABLE_TITLE_AREA: 'Area',
            STR_MANAGE_USER_TABLE_TITLE_PHONENUMBER: 'Phone Number',
            STR_MANAGE_USER_TABLE_TITLE_STATUS: 'Status',
            STR_MANAGE_USER_TABLE_TITLE_ISSYSTEMACCOUNT: 'System Account',
            STR_MANAGE_USER_TABLE_TITLE_PHONENUMBERCONFIRM: 'Phone Number Confirm',
            STR_MANAGE_USER_TABLE_TITLE_ACCESSFAILEDCOUNT: '',
            STR_MANAGE_USER_TABLE_TITLE_LOCKACCOUNT: 'Lock Account',
            STR_MANAGE_USER_TABLE_SEARCH: 'Search name or area',
            STR_MANAGE_USER_TABLE_ROLENAME: 'Role Name',
            STR_MANAGE_USER_TABLE_TITLE_EMAIL: 'Email',
            STR_MANAGE_USER_TABLE_TITLE_DOB: 'Day of birth',
            STR_MANAGE_USER_TABLE_TITLE_ADDRESS: 'Address',
            STR_MANAGE_USER_TABLE_TITLE_CITY: 'City',
            STR_MANAGE_USER_TABLE_TITLE_CITY_NOTFOUND: 'No Results Found',
            STR_MANAGE_USER_TABLE_TITLE_DEPARTMENT: 'Department',
            STR_MANAGE_USER_ADD: 'Add New User',
            STR_MANAGE_USER_TABLE_TITLE_FUNCTIONLIST: 'Function list',

            STR_MANAGE_ROLE: 'Manage Role',
            STR_MANAGE_LIST_ROLE: 'List Roles',
            STR_MANAGE_ROLE_TABLE_SEARCH: 'Search role name',
            STR_MANAGE_ROLE_TABLE_TITLE_PHONENUMBER: 'Phone Number',
            STR_MANAGE_ROLE_TABLE_TITLE_STATUS: 'Status',

            STR_MANAGE_DASHBOARD: 'Dashboard',

            SRT_YOURPROFILE: 'Your profile',
            STR_CHANGEPASSWORD: 'Change password',
            STR_LOGOUT: 'Logout'
        });
        $translateProvider.translations('vn', {

            STR_FOOTER_INFO: 'Bản quyền thuộc PSD © 2019 được phát triển bởi',

            STR_BUTTOM_ADD: 'Thêm mới',
            STR_BUTTOM_DELETE: 'Xóa',
            STR_BUTTOM_EDIT: 'Điều chỉnh',
            STR_BUTTOM_EXPORT: 'Xuất',
            STR_BUTTOM_IMPORT: 'Nhập',
            STR_BUTTOM_BACK: 'Trở về',
            STR_BUTTOM_SAVE: 'Lưu',
            STR_BUTTOM_CLEAR: 'Dọn dẹp',

            STR_STATUS_USER_A: 'Hoạt động',
            STR_STATUS_USER_I: 'Ngưng hoạt động',

            STR_MANAGE_USER: 'Quản lý nhân viên',
            STR_MANAGE_LIST_USER: 'Danh sách nhân viên',
            STR_MANAGE_USER_TABLE_TITLE_USERNAME: 'Tài khoản',
            STR_MANAGE_USER_TABLE_TITLE_FULLNAME: 'Tên',
            STR_MANAGE_USER_TABLE_TITLE_AREA: 'Khu vực',
            STR_MANAGE_USER_TABLE_TITLE_PHONENUMBER: 'Số ĐT',
            STR_MANAGE_USER_TABLE_TITLE_STATUS: 'Trạng thái',
            STR_MANAGE_USER_TABLE_TITLE_ISSYSTEMACCOUNT: 'Tài khoản hệ thống',
            STR_MANAGE_USER_TABLE_TITLE_PHONENUMBERCONFIRM: 'Xác nhận số ĐT',
            STR_MANAGE_USER_TABLE_TITLE_ACCESSFAILEDCOUNT: 'Số lần login sai',
            STR_MANAGE_USER_TABLE_TITLE_LOCKACCOUNT: 'Tài khoản khóa',
            STR_MANAGE_USER_TABLE_SEARCH: 'Tìm kiếm',
            STR_MANAGE_USER_TABLE_ROLENAME: 'Cấp bậc',
            STR_MANAGE_USER_TABLE_TITLE_EMAIL: 'Thư điện tử',
            STR_MANAGE_USER_TABLE_TITLE_DOB: 'Ngày sinh',
            STR_MANAGE_USER_TABLE_TITLE_ADDRESS: 'Địa chỉ',
            STR_MANAGE_USER_TABLE_TITLE_CITY: 'Thành phố',
            STR_MANAGE_USER_TABLE_TITLE_CITY_NOTFOUND: 'Không tìm thấy',
            STR_MANAGE_USER_TABLE_TITLE_DEPARTMENT: 'Bộ phận',
            STR_MANAGE_USER_ADD: 'Thêm mới người dùng',
            STR_MANAGE_USER_TABLE_TITLE_FUNCTIONLIST: 'Danh sách chức năng',

            STR_MANAGE_ROLE: 'Quản lý quyền',

            STR_MANAGE_DASHBOARD: 'Thống kê',

            SRT_YOURPROFILE: 'Tài khoản',
            STR_CHANGEPASSWORD: 'Đổi mật khẩu',
            STR_LOGOUT: 'Đăng xuất'
        });

        $translateProvider.preferredLanguage('vn');
        $translateProvider.useSanitizeValueStrategy('sanitizeParameters');
    }
})();