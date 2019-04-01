using System.ComponentModel;

namespace PetroTech.Common.Resource
{
    public static class Helper
    {
        public class Enum
        {
            public enum Status
            {
                [Description("Active")]
                A = 1,

                [Description("Inactive")]
                I = 2
            }

            public enum Notification
            {
                [Description("Data not found, please try again!")]
                STR_DATA_NOT_FOUND = 1,

                [Description("Add new user successfully!")]
                STR_ADD_USER_SUCCESS = 2,

                [Description("Add new user falid!")]
                STR_ADD_USER_FAILD = 3,

                [Description("Update user successfully!")]
                STR_UPDATE_USER_SUCCESS = 4,

                [Description("Update user falid!")]
                STR_UPDATE_USER_FAILD = 5,

                [Description("Delete role successfully!")]
                STR_DELETE_ROLE_SUCCESS = 6,

                [Description("Can't delete this role, kindly check with administration!")]
                STR_DELETE_ROLE_FAILD = 7,

                [Description("Add new role successfully!")]
                STR_ADD_ROLE_SUCCESS = 8,

                [Description("Add new role faild!")]
                STR_ADD_ROLE_FAILD = 9,
            }

            public enum ValidationError
            {
                [Description("User Name must be more than 6 character")]
                STR_USERNAME_LENGTH = 1,

                [Description("This User Name can use")]
                STR_USERNAME_CANUSE = 2,

                [Description("This User Name can't use")]
                STR_USERNAME_CANNOTUSE = 3,

                [Description("Email must be correct format account@bbpetro.com.vn")]
                STR_EMAIL_FORMAT = 4,

                [Description("Phone Number just can be number")]
                STR_PHONE_FORMAT = 5,

                [Description("This filed can't use special character")]
                STR_SPECIALCHAR = 6,

                [Description("Please select value")]
                STR_SELECT = 7,

                [Description("Role Code must be more then 3 character")]
                STR_ROLECODE_LENGTH = 8,

                [Description("This Role Code can use")]
                STR_ROLECODE_CANUSE = 9,

                [Description("This Role Code can't use")]
                STR_ROLECODE_CANNOTUSE = 10,
            }
        }

        public class Constant
        {
            public enum ConstantFiled
            {
                [Description("UserName")]
                CONST_USERNAME = 1,

                [Description("FullName")]
                CONST_FULLNAME = 2,

                [Description("Email")]
                CONST_EMAIL = 3,

                [Description("PhoneNumber")]
                CONST_PHONE = 4,

                [Description("Area")]
                CONST_AREA = 5,

                [Description("Status")]
                CONST_STATUS = 6,

                [Description("Department")]
                CONST_DEPARTMENT = 7,

                [Description("Role")]
                CONST_ROLE = 8,

                [Description("Address")]
                CONST_ADDRESS = 9,

                [Description("City")]
                CONST_CITY = 10,

                [Description("RoleCode")]
                CONST_ROLECODE = 11,

                [Description("RoleName")]
                CONST_ROLENAME = 12,
            }

            public enum ConstantEmailDomain
            {
                [Description("psd.com.vn")]
                CONST_GMAIL_DOMAIN = 1,
            }

        }
    }
}