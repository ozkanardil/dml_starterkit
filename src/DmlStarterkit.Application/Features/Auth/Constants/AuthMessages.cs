using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmlStarterkit.Application.Features.Auth.Constants
{
    public static class AuthMessages
    {
        public static string UserNotFound = "User not found.";
        public static string UserNotApproved = "User not approved.";
        public static string UserLoginOk = "Login succesfull.";
        public static string UserLoginErr = "Login error.";

        public static string ThisEmailInUse = "This email is in use";

        public static string UserCreateSuccess = "User has been created.";
        public static string UserCreateError = "User can not be created.";
        public static string RequestCanNotBeNull = "Value cannot be null.";
        public static string GuardStaticTokenIsNotValid = "Invalid request.";
    }
}
