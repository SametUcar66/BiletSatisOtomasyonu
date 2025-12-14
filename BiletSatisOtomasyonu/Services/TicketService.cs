using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using BiletSatisOtomasyonu.Helpers;

namespace BiletSatisOtomasyonu.Services
{
    /// <summary>
    /// Bilet işlemleri
    /// </summary>
    public static class TicketService
    {
        /// <summary>
        /// Tüm terminalleri getirir
        /// </summary>
        public static DataTable GetTerminals()
        {
            string query = @"
                SELECT terminal_id, 
                       terninal_name || ' (' || terminal_city || ')' AS name, 
                       terminal_city 
                FROM terminals 
                ORDER BY terminal_city";
            return DatabaseHelper.ExecuteQuery(query);
        }

        /// <summary>
        /// Araç tipine göre terminalleri getirir
        /// </summary>
        public static DataTable GetTerminalsByType(string vehicleType)
        {
            string filter;
            switch (vehicleType)
            {
                case "Uçak":
                    filter = "terninal_name LIKE '%Havalimanı%'";
                    break;
                case "Tren":
                    filter = "terninal_name LIKE '%Garı%' OR terninal_name LIKE '%YHT%'";
                    break;
                case "Otobüs":
                    filter = "terninal_name LIKE '%Otogar%' OR terninal_name LIKE '%AŞTİ%'";
                    break;
                default:
                    filter = "1=1";
                    break;
            }

            string query = $@"
                SELECT terminal_id, 
                       terninal_name || ' (' || terminal_city || ')' AS name, 
                       terminal_city 
                FROM terminals 
                WHERE {filter}
                ORDER BY terminal_city";
            return DatabaseHelper.ExecuteQuery(query);
        }

        /// <summary>
        /// Seferleri arar
        /// </summary>
        public static DataTable SearchTrips(string vehicleType, DateTime? date = null,
            string departureTerminal = null, string arrivalTerminal = null)
        {
            var parameters = new List<SQLiteParameter>();

            string query = @"
                SELECT 
                    t.trip_id AS 'Sefer ID',
                    r.name AS 'Güzergah',
                    t.departure_time AS 'Kalkış Zamanı',
                    t.base_price AS 'Fiyat (₺)',
                    vt.type_name AS 'Araç Tipi',
                    v.plate_number AS 'Plaka',
                    t.trip_status AS 'Durum'
                FROM trips t
                INNER JOIN routes r ON t.route_id = r.route_id
                INNER JOIN vehicles v ON t.vehicle_id = v.vehicle_id
                INNER JOIN vehicle_types vt ON v.type_id = vt.type_id
                WHERE vt.type_name = @vehicleType";

            parameters.Add(new SQLiteParameter("@vehicleType", vehicleType));

            if (date.HasValue)
            {
                query += " AND DATE(t.departure_time) = DATE(@date)";
                parameters.Add(new SQLiteParameter("@date", date.Value.ToString("yyyy-MM-dd")));
            }

            query += " ORDER BY t.departure_time";

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }

        /// <summary>
        /// Tüm seferleri getirir
        /// </summary>
        public static DataTable SearchAllTrips(DateTime? date = null,
            string departureTerminal = null, string arrivalTerminal = null)
        {
            var parameters = new List<SQLiteParameter>();

            string query = @"
                SELECT 
                    t.trip_id AS 'Sefer ID',
                    r.name AS 'Güzergah',
                    t.departure_time AS 'Kalkış Zamanı',
                    t.base_price AS 'Fiyat (₺)',
                    vt.type_name AS 'Araç Tipi',
                    v.plate_number AS 'Plaka',
                    t.trip_status AS 'Durum'
                FROM trips t
                INNER JOIN routes r ON t.route_id = r.route_id
                INNER JOIN vehicles v ON t.vehicle_id = v.vehicle_id
                INNER JOIN vehicle_types vt ON v.type_id = vt.type_id
                WHERE 1=1";

            if (date.HasValue)
            {
                query += " AND DATE(t.departure_time) = DATE(@date)";
                parameters.Add(new SQLiteParameter("@date", date.Value.ToString("yyyy-MM-dd")));
            }

            query += " ORDER BY t.departure_time";

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }

        /// <summary>
        /// Dolu koltukları getirir
        /// </summary>
        public static List<int> GetOccupiedSeats(int tripId)
        {
            var seats = new List<int>();

            string query = @"
                SELECT s.seat_number 
                FROM tickets tk 
                INNER JOIN seats s ON tk.seat_id = s.seat_id 
                WHERE tk.trip_id = @tripId AND tk.status = 'Sold'";

            var dt = DatabaseHelper.ExecuteQuery(query, new SQLiteParameter("@tripId", tripId));

            foreach (DataRow row in dt.Rows)
            {
                if (int.TryParse(row["seat_number"].ToString(), out int seatNum))
                    seats.Add(seatNum);
            }

            return seats;
        }

        /// <summary>
        /// Bilet satın alır
        /// </summary>
        public static bool PurchaseTicket(int tripId, int seatNumber, int startTerminalId,
            int endTerminalId, decimal price, string passengerName, int? userId = null)
        {
            try
            {
                using (var conn = DatabaseHelper.CreateConnection())
                {
                    conn.Open();

                    // Seat ID bul
                    string seatQuery = @"
                        SELECT s.seat_id FROM seats s
                        INNER JOIN vehicle_units vu ON s.unit_id = vu.unit_id
                        INNER JOIN vehicles v ON vu.vehicle_id = v.vehicle_id
                        INNER JOIN trips t ON t.vehicle_id = v.vehicle_id
                        WHERE t.trip_id = @tripId AND CAST(s.seat_number AS INTEGER) = @seatNumber";

                    int seatId = 0;
                    using (var cmd = new SQLiteCommand(seatQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tripId", tripId);
                        cmd.Parameters.AddWithValue("@seatNumber", seatNumber);
                        var result = cmd.ExecuteScalar();
                        if (result == null) return false;
                        seatId = Convert.ToInt32(result);
                    }

                    // PNR oluştur
                    string pnr = "PNR" + DateTime.Now.Ticks.ToString().Substring(8);

                    // Bilet kaydet
                    string insertQuery = @"
                        INSERT INTO tickets (pnr_code, trip_id, user_id, seat_id, passenger_name, 
                                           start_terminal_id, end_terminal_id, final_price, status) 
                        VALUES (@pnr, @tripId, @userId, @seatId, @name, @startId, @endId, @price, 'Sold')";

                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pnr", pnr);
                        cmd.Parameters.AddWithValue("@tripId", tripId);
                        cmd.Parameters.AddWithValue("@userId", userId.HasValue ? (object)userId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@seatId", seatId);
                        cmd.Parameters.AddWithValue("@name", passengerName);
                        cmd.Parameters.AddWithValue("@startId", startTerminalId > 0 ? startTerminalId : 1);
                        cmd.Parameters.AddWithValue("@endId", endTerminalId > 0 ? endTerminalId : 2);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kullanıcının biletlerini getirir
        /// </summary>
        public static DataTable GetUserTickets(int userId)
        {
            string query = @"
                SELECT 
                    tk.pnr_code AS 'PNR',
                    r.name AS 'Güzergah',
                    t.departure_time AS 'Kalkış',
                    s.seat_number AS 'Koltuk',
                    tk.final_price AS 'Fiyat (₺)',
                    tk.status AS 'Durum'
                FROM tickets tk
                INNER JOIN trips t ON tk.trip_id = t.trip_id
                INNER JOIN routes r ON t.route_id = r.route_id
                INNER JOIN seats s ON tk.seat_id = s.seat_id
                WHERE tk.user_id = @userId
                ORDER BY t.departure_time DESC";

            return DatabaseHelper.ExecuteQuery(query, new SQLiteParameter("@userId", userId));
        }

        /// <summary>
        /// Terminal ID'sini isimden getirir
        /// </summary>
        public static int GetTerminalIdByName(string terminalNameWithCity)
        {
            if (string.IsNullOrEmpty(terminalNameWithCity))
                return 0;

            // "Terminal Adı (Şehir)" formatından terminal adını çıkar
            string terminalName = terminalNameWithCity;
            int parenIndex = terminalNameWithCity.LastIndexOf(" (");
            if (parenIndex > 0)
            {
                terminalName = terminalNameWithCity.Substring(0, parenIndex);
            }

            var result = DatabaseHelper.ExecuteScalar(
                "SELECT terminal_id FROM terminals WHERE terninal_name = @name LIMIT 1",
                new SQLiteParameter("@name", terminalName));

            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        /// <summary>
        /// Terminallerin şehir bilgisini alır
        /// </summary>
        public static string GetTerminalCity(string terminalName)
        {
            if (string.IsNullOrEmpty(terminalName))
                return "";

            var result = DatabaseHelper.ExecuteScalar(
                "SELECT terminal_city FROM terminals WHERE terninal_name = @name",
                new SQLiteParameter("@name", terminalName));

            return result?.ToString() ?? "";
        }

        /// <summary>
        /// İki terminalin aynı şehirde olup olmadığını kontrol eder
        /// </summary>
        public static bool IsSameCity(string terminal1, string terminal2)
        {
            string city1 = GetTerminalCity(terminal1);
            string city2 = GetTerminalCity(terminal2);

            if (string.IsNullOrEmpty(city1) || string.IsNullOrEmpty(city2))
                return false;

            return city1.Equals(city2, StringComparison.OrdinalIgnoreCase);
        }
    }
}