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
            }

            public enum ValidationError
            {
                [Description("User Name must be more than 6 character")]
                STR_USERNAME_LENGTH = 1,

                [Description("This User Name can use")]
                STR_USERNAME_CANUSE = 2,

                [Description("This User Name can't use")]
                STR_USERNAME_CANNOTUSE = 3,

                [Description("User Name can't use special character")]
                STR_USERNAME_SPECIALCHAR = 4,

                [Description("Full Name can't use special character")]
                STR_FULLNAME_SPECIALCHAR = 5,

                [Description("Email must be correct format account@psd.com.vn")]
                STR_EMAIL_FORMAT = 6,

                [Description("Email must be more than 6 character")]
                STR_EMAIL_LENGTH = 7,
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
            }

            public enum ConstantEmailDomain
            {
                [Description("psd.com.vn")]
                CONST_GMAIL_DOMAIN = 1,
            }

        }
    }
}