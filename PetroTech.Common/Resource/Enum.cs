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
                STR_UPDATE_SUCCESS = 4,

                [Description("Update user falid!")]
                STR_UPDATE_FAILD = 5,
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
            }

            public enum ConstantEmailDomain
            {
                [Description("psd.com.vn")]
                CONST_GMAIL_DOMAIN = 1,
            }

        }
    }
}