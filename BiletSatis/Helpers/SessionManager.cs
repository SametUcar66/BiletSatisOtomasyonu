using BiletSatis.Models;

namespace BiletSatis.Helpers
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }
        public static int? CurrentAgencyId { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsSuperAdmin => CurrentUser?.UserType == UserType.SuperAdmin;
        public static bool IsAgencyManager => CurrentUser?.UserType == UserType.AgencyManager;
        public static bool IsAgencyEmployee => CurrentUser?.UserType == UserType.AgencyEmployee;
        public static bool IsDriver => CurrentUser?.UserType == UserType.Driver;
        public static bool IsCompany => CurrentUser?.UserType == UserType.Company;
        public static bool IsIndividual => CurrentUser?.UserType == UserType.Individual;

        public static void Logout()
        {
            CurrentUser = null;
            CurrentAgencyId = null;
        }
    }
}