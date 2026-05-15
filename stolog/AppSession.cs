using System;

namespace EVS
{
    public static class AppSession
    {
        public static UserSession CurrentUser { get; set; }

        public static bool IsAuthenticated
        {
            get { return CurrentUser != null; }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool HasRole(string requiredRole)
        {
            if (CurrentUser == null) return false;
            return string.Equals(CurrentUser.UserType, requiredRole, StringComparison.OrdinalIgnoreCase);
        }

        public static long? GetCurrentUserId()
        {
            return CurrentUser?.UserId;
        }

        public static string GetCurrentUserLogin()
        {
            return CurrentUser?.Login ?? "Гость";
        }

        public static string GetCurrentUserType()
        {
            return CurrentUser?.UserType ?? "unknown";
        }
    }
}