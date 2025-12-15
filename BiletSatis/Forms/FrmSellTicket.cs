using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms
{
    public class FrmSellTicket : Form
    {
        private int tripId;
        private decimal price;
        private TextBox txtPassengerName;
        private TextBox txtPassengerTC;
        private TextBox txtPassengerPhone;
        private ComboBox cmbSeat;
        private ComboBox cmbPaymentType;
        private Label lblPrice;
        private Button btnSell;
        private Button btnCancel;

        public FrmSellTicket(int tripId, string firma, string kalkis, decimal price)
        {
            this.tripId = tripId;
            this.price = price;
            InitializeComponents(firma, kalkis);
            LoadAvailableSeats();
        }

        private void InitializeComponents(string firma, string kalkis)
        {
            this.Text = "Bilet Sat";
            this.Size = new Size(420, 480);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Sefer bilgisi
            var pnlInfo = new Panel
            {
                Location = new Point(20, 15),
                Size = new Size(360, 50),
                BackColor = Color.FromArgb(240, 248, 255)
            };
            this.Controls.Add(pnlInfo);

            var lblInfo = new Label
            {
                Text = $"🚌 {firma}\n🕐 Kalkış: {kalkis}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 8),
                AutoSize = true
            };
            pnlInfo.Controls.Add(lblInfo);

            int y = 80;
            int spacing = 55;

            // Yolcu Adı
            AddLabel("Yolcu Adı Soyadı *", 20, y);
            txtPassengerName = AddTextBox(20, y + 20, 360);
            y += spacing;

            // TC No
            AddLabel("TC Kimlik No *", 20, y);
            txtPassengerTC = AddTextBox(20, y + 20, 200);
            txtPassengerTC.MaxLength = 11;
            y += spacing;

            // Telefon
            AddLabel("Telefon *", 20, y);
            txtPassengerPhone = AddTextBox(20, y + 20, 200);
            y += spacing;

            // Koltuk Seçimi
            AddLabel("Koltuk *", 20, y);
            cmbSeat = new ComboBox
            {
                Location = new Point(20, y + 20),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbSeat);

            // Ödeme Tipi
            AddLabel("Ödeme Tipi *", 150, y);
            cmbPaymentType = new ComboBox
            {
                Location = new Point(150, y + 20),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPaymentType.Items.Add("💵 Nakit");
            cmbPaymentType.Items.Add("💳 Kredi Kartı");
            cmbPaymentType.Items.Add("🏦 Havale/EFT");
            cmbPaymentType.SelectedIndex = 0;
            this.Controls.Add(cmbPaymentType);
            y += spacing;

            // Fiyat
            lblPrice = new Label
            {
                Text = $"💰 Toplam: ₺{price:N2}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(20, y),
                AutoSize = true
            };
            this.Controls.Add(lblPrice);
            y += 50;

            // Butonlar
            btnSell = new Button
            {
                Text = "🎫 Satışı Tamamla",
                Location = new Point(100, y),
                Size = new Size(150, 45),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSell.FlatAppearance.BorderSize = 0;
            btnSell.Click += BtnSell_Click;
            this.Controls.Add(btnSell);

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(260, y),
                Size = new Size(100, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancel);
        }

        private void AddLabel(string text, int x, int y)
        {
            this.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            });
        }

        private TextBox AddTextBox(int x, int y, int width)
        {
            var txt = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 25),
                Font = new Font("Segoe UI", 10)
            };
            this.Controls.Add(txt);
            return txt;
        }

        private void LoadAvailableSeats()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    int capacity = 46;
                    string capSql = "SELECT v.Capacity FROM Trips t INNER JOIN Vehicles v ON t.VehicleId = v.Id WHERE t.Id = @TripId";
                    using (var cmd = new SQLiteCommand(capSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TripId", tripId);
                        var result = cmd.ExecuteScalar();
                        if (result != null) capacity = Convert.ToInt32(result);
                    }

                    string soldSql = "SELECT SeatNumber FROM Tickets WHERE TripId = @TripId AND Status IN (0, 1)";
                    var soldSeats = new System.Collections.Generic.List<string>();
                    using (var cmd = new SQLiteCommand(soldSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TripId", tripId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                soldSeats.Add(reader["SeatNumber"].ToString());
                        }
                    }

                    cmbSeat.Items.Clear();
                    for (int i = 1; i <= capacity; i++)
                    {
                        string seatNo = i.ToString();
                        if (!soldSeats.Contains(seatNo))
                            cmbSeat.Items.Add(seatNo);
                    }

                    if (cmbSeat.Items.Count > 0)
                        cmbSeat.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koltuk yükleme hatası: " + ex.Message);
            }
        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassengerName.Text))
            {
                MessageBox.Show("Yolcu adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassengerTC.Text) || txtPassengerTC.Text.Length != 11)
            {
                MessageBox.Show("Geçerli bir TC Kimlik No girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSeat.SelectedItem == null)
            {
                MessageBox.Show("Lütfen koltuk seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string ticketNo = $"TKT-{DateTime.Now:yyyyMMdd}-{new Random().Next(10000, 99999)}";

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Bilet oluştur
                            string ticketSql = @"INSERT INTO Tickets 
                                (TicketNo, TripId, UserId, PassengerName, PassengerTCNo, PassengerPhone, 
                                 SeatNumber, Price, DiscountAmount, FinalPrice, Status, PurchaseDate, SoldBy)
                                VALUES 
                                (@TicketNo, @TripId, @UserId, @PassengerName, @TC, @Phone,
                                 @Seat, @Price, 0, @Price, 1, @Date, @SoldBy);
                                SELECT last_insert_rowid();";

                            int ticketId;
                            using (var cmd = new SQLiteCommand(ticketSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TicketNo", ticketNo);
                                cmd.Parameters.AddWithValue("@TripId", tripId);
                                cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                                cmd.Parameters.AddWithValue("@PassengerName", txtPassengerName.Text.Trim());
                                cmd.Parameters.AddWithValue("@TC", txtPassengerTC.Text.Trim());
                                cmd.Parameters.AddWithValue("@Phone", txtPassengerPhone.Text.Trim());
                                cmd.Parameters.AddWithValue("@Seat", cmbSeat.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@Price", price);
                                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@SoldBy", SessionManager.CurrentUser.Id);

                                ticketId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Ödeme kaydı
                            string paymentSql = @"INSERT INTO Payments (TicketId, UserId, Amount, PaymentType, Status, PaymentDate)
                                                 VALUES (@TicketId, @UserId, @Amount, @PaymentType, 1, @Date)";
                            using (var cmd = new SQLiteCommand(paymentSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TicketId", ticketId);
                                cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                                cmd.Parameters.AddWithValue("@Amount", price);
                                cmd.Parameters.AddWithValue("@PaymentType", cmbPaymentType.SelectedIndex);
                                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }

                            // Boş koltuk güncelle
                            string updateSql = "UPDATE Trips SET AvailableSeats = AvailableSeats - 1 WHERE Id = @TripId";
                            using (var cmd = new SQLiteCommand(updateSql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TripId", tripId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    $"✅ Bilet satışı tamamlandı!\n\n" +
                    $"Bilet No: {ticketNo}\n" +
                    $"Yolcu: {txtPassengerName.Text}\n" +
                    $"Koltuk: {cmbSeat.SelectedItem}\n" +
                    $"Tutar: ₺{price:N2}",
                    "Satış Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}