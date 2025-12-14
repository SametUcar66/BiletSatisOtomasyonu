using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using BiletSatisOtomasyonu.Helpers;

namespace BiletSatisOtomasyonu.Services
{
    /// <summary>
    /// Bilet i?lemleri servisi
    /// </summary>
    public static class TicketService
    {
        /// <summary>
        /// Terminalleri getirir
        /// </summary>
        public static DataTable GetTerminals()
        {
            string query = "SELECT id, name FROM terminals ORDER BY name";
            return DatabaseHelper.ExecuteQuery(query);
        }

        /// <summary>
        /// Seferleri araç tipine göre getirir
        /// </summary>
        public static DataTable SearchTrips(string vehicleType)
        {
            string query = @"
                SELECT 
                    t.id AS 'Sefer ID',
                    t.name AS 'Sefer Ad?',
                    r.firstname AS 'Güzergah',
                    te.expenses AS 'Fiyat (?)',
                    v.name AS 'Araç Ad?'
                FROM trips t
                INNER JOIN routes r ON t.driver = r.id
                INNER JOIN vehicles v ON t.vehicles = v.id
                INNER JOIN vehicle_types vt ON v.vehicle_types = vt.agency
                LEFT JOIN trip_expenses te ON t.id = te.trip_expenses
                WHERE vt.vehicle_type = @vehicleType
                ORDER BY t.name";

            return DatabaseHelper.ExecuteQuery(query,
                new SQLiteParameter("@vehicleType", vehicleType));
        }

        /// <summary>
        /// Belirli bir seferdeki dolu koltuklar? getirir
        /// </summary>
        public static List<int> GetOccupiedSeats(int tripId)
        {
            var occupiedSeats = new List<int>();

            try
            {
                string query = @"SELECT s.seats FROM seats s 
                                 INNER JOIN tickets tk ON s.ticket = tk.id 
                                 WHERE tk.trip_expenses = @tripId";

                var dt = DatabaseHelper.ExecuteQuery(query,
                    new SQLiteParameter("@tripId", tripId));

                foreach (DataRow row in dt.Rows)
                {
                    if (row["seats"] != DBNull.Value)
                    {
                        occupiedSeats.Add(Convert.ToInt32(row["seats"]));
                    }
                }
            }
            catch
            {
            }

            return occupiedSeats;
        }

        /// <summary>
        /// Bilet sat?n al?r
        /// </summary>
        public static bool PurchaseTicket(int tripId, int seatNumber, string ticketPrefix, string ticketName, string route)
        {
            try
            {
                using (var connection = DatabaseHelper.CreateConnection())
                {
                    connection.Open();

                    // Bilet kayd? olu?tur
                    string ticketCode = ticketPrefix + DateTime.Now.Ticks;
                    string ticketId = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                    string insertTicket = @"INSERT INTO tickets (ticket, ticket_id, trip_expenses) 
                                            VALUES (@ticket, @ticketId, @tripId)";

                    using (var cmd = new SQLiteCommand(insertTicket, connection))
                    {
                        cmd.Parameters.AddWithValue("@ticket", ticketCode);
                        cmd.Parameters.AddWithValue("@ticketId", ticketId);
                        cmd.Parameters.AddWithValue("@tripId", tripId);
                        cmd.ExecuteNonQuery();
                    }

                    long biletId = connection.LastInsertRowId;

                    // Koltuk kayd? olu?tur
                    string insertSeat = @"INSERT INTO seats (seats, ticket, ticketname, terminame) 
                                          VALUES (@seats, @ticket, @ticketname, @terminame)";

                    using (var cmd = new SQLiteCommand(insertSeat, connection))
                    {
                        cmd.Parameters.AddWithValue("@seats", seatNumber);
                        cmd.Parameters.AddWithValue("@ticket", biletId);
                        cmd.Parameters.AddWithValue("@ticketname", ticketName);
                        cmd.Parameters.AddWithValue("@terminame", route);
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
    }
}