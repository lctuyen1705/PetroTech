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
            }

            public enum ValidationError
            {
                [Description("User Name must be more than 6 character!")]
                STR_ERROR_USERNAME = 1,

                [Description("This UserName can use!")]
                STR_USERNAME_CANUSE = 2,

                [Description("This UserName can't use!")]
                STR_USERNAME_CANNOTUSE = 3,
            }
        }
    }
}