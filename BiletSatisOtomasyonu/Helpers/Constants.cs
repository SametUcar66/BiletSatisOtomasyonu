using System.Drawing;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Sabitler
    /// </summary>
    public static class Constants
    {
        // Roller
        public const int ROLE_SUPER_ADMIN = 1;
        public const int ROLE_PASSENGER = 5;

        // Araç Tipleri
        public const string VEHICLE_BUS = "Otobüs";
        public const string VEHICLE_PLANE = "Uçak";
        public const string VEHICLE_TRAIN = "Tren";

        // Koltuk Sayıları
        public const int SEAT_COUNT_BUS = 45;
        public const int SEAT_COUNT_PLANE = 60;
        public const int SEAT_COUNT_TRAIN = 40;

        // Fiyatlar
        public const decimal PRICE_BUS = 500m;
        public const decimal PRICE_PLANE = 1000m;
        public const decimal PRICE_TRAIN = 350m;

        // Renkler
        public static readonly Color ColorPrimary = Color.FromArgb(0, 122, 204);
        public static readonly Color ColorSeatAvailable = Color.FromArgb(0, 150, 0);
        public static readonly Color ColorSeatOccupied = Color.FromArgb(192, 0, 0);
        public static readonly Color ColorSeatSelected = Color.FromArgb(0, 122, 204);
        public static readonly Color ColorBackground = Color.FromArgb(45, 45, 48);
    }
}