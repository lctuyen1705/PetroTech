(function (app) {

    app.controller('dashboardController', dashboardController);

    function dashboardController($translateProvider) {
        $translateProvider.translations('en', {

            //=====GOBAL-STATUS_USER_EN=====
            STR_STATUS_USER_A: 'Active',
            STR_STATUS_USER_I: 'InActive',

            //=====MENU_ADMIN-USER_EN=====
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

            //=====MENU_ADMIN-ROLE_EN=====
            STR_MANAGE_ROLE: 'Manage Role',

            //=====MENU_ADMIN-DASHBOARD_EN=====
            STR_MANAGE_DASHBOARD: 'Dashboard',

            //=====MENU_ADMIN-SETTING_USER_EN=====
            SRT_YOURPROFILE: 'Your profile',
            STR_CHANGEPASSWORD: 'Change password',
            STR_LOGOUT: 'Logout'
        });
        $translateProvider.translations('vn', {

            //=====GOBAL-STATUS_USER_VN=====
            STR_STATUS_USER_A: 'Hoạt động',
            STR_STATUS_USER_I: 'Ngưng hoạt động',

            //=====MENU_ADMIN-USER_VN=====
            STR_MANAGE_USER: 'Quản lý nhân viên',
            STR_MANAGE_LIST_USER: 'Danh sách nhân viên',
            STR_MANAGE_USER_TABLE_TITLE_USERNAME: 'Tài khoản',
            STR_MANAGE_USER_TABLE_TITLE_FULLNAME: 'Tên',
            STR_MANAGE_USER_TABLE_TITLE_AREA: 'Khu vực',
            STR_MANAGE_USER_TABLE_TITLE_PHONENUMBER: 'Số ĐT',
            STR_MANAGE_USER_TABLE_TITLE_STATUS: 'Trạng thái',
            STR_MANAGE_USER_TABLE_TITLE_ISSYSTEMACCOUNT: 'Tài khoản hệ thống',
            STR_MANAGE_USER_TABLE_TITLE_PHONENUMBERCONFIRM: 'Xác nhận số ĐT',
            STR_MANAGE_USER_TABLE_TITLE_ACCESSFAILEDCOUNT: 'Số lần login Sai',
            STR_MANAGE_USER_TABLE_TITLE_LOCKACCOUNT: 'Tài khoản khóa',

            //=====MENU_ADMIN-ROLE_VN=====
            STR_MANAGE_ROLE: 'Quản lý quyền',

            //=====MENU_ADMIN-DASHBOARD_VN=====
            STR_MANAGE_DASHBOARD: 'Thống kê',

            //=====MENU_ADMIN-SETTING_USER_VN=====
            SRT_YOURPROFILE: 'Tài khoản',
            STR_CHANGEPASSWORD: 'Đổi mật khẩu',
            STR_LOGOUT: 'Đăng xuất'
        });
        $translateProvider.preferredLanguage('vn');
        $translateProvider.useSanitizeValueStrategy('sanitizeParameters');
    }

})(angular.module('petrotech.dashboard'));