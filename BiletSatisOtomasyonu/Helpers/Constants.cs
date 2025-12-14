using System.Drawing;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Uygulama genelinde kullanılan sabitler
    /// </summary>
    public static class Constants
    {
        #region Rol ID'leri

        public const int ROLE_SUPER_ADMIN = 1;
        public const int ROLE_AGENCY_ADMIN = 2;
        public const int ROLE_STAFF = 3;
        public const int ROLE_DRIVER = 4;
        public const int ROLE_PASSENGER = 5;

        #endregion

        #region Acenta ID'leri

        public const int AGENCY_PERSONAL = 4;

        #endregion

        #region Araç Tipleri

        public const string VEHICLE_TYPE_BUS = "Otobüs";
        public const string VEHICLE_TYPE_PLANE = "Uçak";
        public const string VEHICLE_TYPE_TRAIN = "Tren";

        #endregion

        #region Bilet Prefix'leri

        public const string TICKET_PREFIX_BUS = "OTB-";
        public const string TICKET_PREFIX_PLANE = "UCK-";
        public const string TICKET_PREFIX_TRAIN = "TRN-";

        #endregion

        #region Koltuk Sayıları

        public const int SEAT_COUNT_BUS = 45;
        public const int SEAT_COUNT_PLANE = 60;
        public const int SEAT_COUNT_TRAIN = 40;

        #endregion

        #region Varsayılan Fiyatlar

        public const decimal DEFAULT_PRICE_BUS = 250m;
        public const decimal DEFAULT_PRICE_PLANE = 500m;
        public const decimal DEFAULT_PRICE_TRAIN = 150m;

        #endregion

        #region Tema Renkleri

        public static readonly Color ColorPrimary = Color.FromArgb(0, 122, 204);
        public static readonly Color ColorSuccess = Color.FromArgb(0, 192, 0);
        public static readonly Color ColorDanger = Color.FromArgb(192, 0, 0);
        public static readonly Color ColorWarning = Color.FromArgb(255, 128, 0);

        public static readonly Color ColorBackgroundDark = Color.FromArgb(30, 30, 30);
        public static readonly Color ColorBackgroundMedium = Color.FromArgb(45, 45, 48);
        public static readonly Color ColorBackgroundLight = Color.FromArgb(60, 60, 60);

        public static readonly Color ColorTextActive = Color.White;
        public static readonly Color ColorTextInactive = Color.FromArgb(180, 180, 180);
        public static readonly Color ColorSeatAvailable = Color.FromArgb(0, 150, 0);
        public static readonly Color ColorSeatOccupied = Color.FromArgb(192, 0, 0);
        public static readonly Color ColorSeatSelected = Color.FromArgb(0, 122, 204);

        #endregion

        #region Placeholder Metinleri

        public const string PLACEHOLDER_EMAIL = "E-posta adresi";
        public const string PLACEHOLDER_PASSWORD = "Parola";
        public const string PLACEHOLDER_FULLNAME = "Ad Soyad";
        public const string PLACEHOLDER_SELECT_DEPARTURE = "-- Kalkış Seçin --";
        public const string PLACEHOLDER_SELECT_ARRIVAL = "-- Varış Seçin --";

        #endregion
    }
}