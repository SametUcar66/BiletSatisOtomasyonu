using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using BiletSatis.Data;
using BiletSatis.Helpers;

namespace BiletSatis.Forms
{
    public class FrmBuyTicket : Form
    {
        private int tripId;
        private decimal price;
        private TextBox txtPassengerName;
        private TextBox txtPassengerTC;
        private TextBox txtPassengerPhone;
        private ComboBox cmbSeat;
        private Label lblPrice;
        private Button btnBuy;
        private Button btnCancel;

        public FrmBuyTicket(int tripId, string firma, string kalkis, decimal price)
        {
            this.tripId = tripId;
            this.price = price;
            InitializeComponents(firma, kalkis);
            LoadAvailableSeats();
        }

        private void InitializeComponents(string firma, string kalkis)
        {
            this.Text = "Bilet Satın Al";
            this.Size = new Size(400, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Sefer bilgisi
            var lblInfo = new Label
            {
                Text = $"🚌 {firma}\n🕐 Kalkış: {kalkis}",
                Font = new Font("Segoe UI", 11),
                Location = new Point(20, 20),
                Size = new Size(340, 50),
                BackColor = Color.FromArgb(240, 248, 255)
            };
            this.Controls.Add(lblInfo);

            int y = 90;
            int spacing = 60;

            // Yolcu Adı
            AddLabel("Yolcu Adı Soyadı *", 20, y);
            txtPassengerName = AddTextBox(20, y + 22, 340);
            if (SessionManager.CurrentUser != null)
                txtPassengerName.Text = SessionManager.CurrentUser.FullName;
            y += spacing;

            // TC No
            AddLabel("TC Kimlik No *", 20, y);
            txtPassengerTC = AddTextBox(20, y + 22, 340);
            txtPassengerTC.MaxLength = 11;
            if (SessionManager.CurrentUser != null && !string.IsNullOrEmpty(SessionManager.CurrentUser.TCNo))
                txtPassengerTC.Text = SessionManager.CurrentUser.TCNo;
            y += spacing;

            // Telefon
            AddLabel("Telefon *", 20, y);
            txtPassengerPhone = AddTextBox(20, y + 22, 340);
            if (SessionManager.CurrentUser != null && !string.IsNullOrEmpty(SessionManager.CurrentUser.Phone))
                txtPassengerPhone.Text = SessionManager.CurrentUser.Phone;
            y += spacing;

            // Koltuk Seçimi
            AddLabel("Koltuk Seçimi *", 20, y);
            cmbSeat = new ComboBox
            {
                Location = new Point(20, y + 22),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.Controls.Add(cmbSeat);
            y += spacing;

            // Fiyat
            lblPrice = new Label
            {
                Text = $"💰 Toplam: ₺{price:N2}",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                Location = new Point(20, y),
                AutoSize = true
            };
            this.Controls.Add(lblPrice);
            y += 50;

            // Butonlar
            btnBuy = new Button
            {
                Text = "🎫 Satın Al",
                Location = new Point(100, y),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnBuy.FlatAppearance.BorderSize = 0;
            btnBuy.Click += BtnBuy_Click;
            this.Controls.Add(btnBuy);

            btnCancel = new Button
            {
                Text = "İptal",
                Location = new Point(230, y),
                Size = new Size(100, 40),
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

                    // Araç kapasitesini al
                    int capacity = 46;
                    string capacitySql = @"SELECT v.Capacity FROM Trips t 
                                          INNER JOIN Vehicles v ON t.VehicleId = v.Id 
                                          WHERE t.Id = @TripId";
                    using (var cmd = new SQLiteCommand(capacitySql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TripId", tripId);
                        var result = cmd.ExecuteScalar();
                        if (result != null) capacity = Convert.ToInt32(result);
                    }

                    // Satılmış koltukları al
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

                    // Boş koltukları listele
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
                MessageBox.Show("Koltuk yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            // Validasyon
            if (string.IsNullOrWhiteSpace(txtPassengerName.Text))
            {
                MessageBox.Show("Yolcu adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassengerName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassengerTC.Text) || txtPassengerTC.Text.Length != 11)
            {
                MessageBox.Show("Geçerli bir TC Kimlik No girin (11 hane)!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassengerTC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassengerPhone.Text))
            {
                MessageBox.Show("Telefon numarası boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassengerPhone.Focus();
                return;
            }

            if (cmbSeat.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir koltuk seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string ticketNo = GenerateTicketNo();

                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Bilet oluştur
                            string sql = @"INSERT INTO Tickets 
                                          (TicketNo, TripId, UserId, PassengerName, PassengerTCNo, PassengerPhone, 
                                           SeatNumber, Price, DiscountAmount, FinalPrice, Status, PurchaseDate)
                                          VALUES 
                                          (@TicketNo, @TripId, @UserId, @PassengerName, @PassengerTC, @PassengerPhone,
                                           @SeatNumber, @Price, 0, @Price, 1, @PurchaseDate)";

                            using (var cmd = new SQLiteCommand(sql, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TicketNo", ticketNo);
                                cmd.Parameters.AddWithValue("@TripId", tripId);
                                cmd.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                                cmd.Parameters.AddWithValue("@PassengerName", txtPassengerName.Text.Trim());
                                cmd.Parameters.AddWithValue("@PassengerTC", txtPassengerTC.Text.Trim());
                                cmd.Parameters.AddWithValue("@PassengerPhone", txtPassengerPhone.Text.Trim());
                                cmd.Parameters.AddWithValue("@SeatNumber", cmbSeat.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@Price", price);
                                cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }

                            // Boş koltuk sayısını güncelle
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
                    $"✅ Bilet başarıyla satın alındı!\n\n" +
                    $"Bilet No: {ticketNo}\n" +
                    $"Koltuk: {cmbSeat.SelectedItem}\n" +
                    $"Tutar: ₺{price:N2}",
                    "Satın Alma Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satın alma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateTicketNo()
        {
            return $"TKT-{DateTime.Now:yyyyMMdd}-{new Random().Next(10000, 99999)}";
        }
    }
}