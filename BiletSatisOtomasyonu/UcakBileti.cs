using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BiletSatisOtomasyonu.Helpers;
using BiletSatisOtomasyonu.Services;

namespace BiletSatisOtomasyonu
{
    public partial class UcakBileti : UserControl
    {
        private int _selectedTripId = -1;
        private int _selectedSeatNo = -1;
        private decimal _ticketPrice = 0;
        private List<int> _occupiedSeats = new List<int>();
        private int _userId = 0;

        public UcakBileti()
        {
            InitializeComponent();
        }

        public UcakBileti(int userId) : this()
        {
            _userId = userId;
        }

        private void UcakBileti_Load(object sender, EventArgs e)
        {
            LoadTerminals();
            SetupDatePicker();
            ThemeHelper.ApplyDarkTheme(dgvSeferler);
        }

        #region Tarih Ayarları

        private void SetupDatePicker()
        {
            dtpTarih.MinDate = new DateTime(2025, 12, 1);
            dtpTarih.MaxDate = new DateTime(2025, 12, 31);
            dtpTarih.Value = new DateTime(2025, 12, 15);
        }

        #endregion

        #region Terminal Yükleme

        private void LoadTerminals()
        {
            try
            {
                var dt = TicketService.GetTerminalsByType(Constants.VEHICLE_TYPE_PLANE);

                cmbKalkis.Items.Clear();
                cmbVaris.Items.Clear();

                cmbKalkis.Items.Add(Constants.PLACEHOLDER_SELECT_DEPARTURE);
                cmbVaris.Items.Add(Constants.PLACEHOLDER_SELECT_ARRIVAL);

                foreach (DataRow row in dt.Rows)
                {
                    string terminalName = row["name"].ToString();
                    cmbKalkis.Items.Add(terminalName);
                    cmbVaris.Items.Add(terminalName);
                }

                cmbKalkis.SelectedIndex = 0;
                cmbVaris.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Havalimanı verileri yüklenirken hata: " + ex.Message);
            }
        }

        #endregion

        #region Sefer Arama

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (cmbKalkis.SelectedIndex <= 0 || cmbVaris.SelectedIndex <= 0)
            {
                MessageHelper.ShowWarning("Lütfen kalkış ve varış havalimanlarını seçin.");
                return;
            }

            string departure = cmbKalkis.SelectedItem.ToString();
            string arrival = cmbVaris.SelectedItem.ToString();

            if (departure == arrival)
            {
                MessageHelper.ShowWarning("Kalkış ve varış havalimanları aynı olamaz.");
                return;
            }

            // Şehir içi uçuş kontrolü - IsSameCity metodunu kullan
            if (TicketService.IsSameCity(departure, arrival))
            {
                MessageHelper.ShowWarning("Şehir içi uçuş yapılamaz. Lütfen farklı şehirler seçin.");
                return;
            }

            SearchTrips();
        }

        private void SearchTrips()
        {
            try
            {
                dgvSeferler.DataSource = null;

                DateTime selectedDate = dtpTarih.Value.Date;
                string departure = cmbKalkis.SelectedItem.ToString();
                string arrival = cmbVaris.SelectedItem.ToString();
                
                var dt = TicketService.SearchTrips(Constants.VEHICLE_TYPE_PLANE, selectedDate, departure, arrival);

                if (dt.Rows.Count == 0)
                {
                    MessageHelper.ShowInfo($"{selectedDate:dd.MM.yyyy} tarihinde bu güzergahta uçuş bulunamadı.");
                }
                else
                {
                    dgvSeferler.DataSource = dt;

                    if (dgvSeferler.Columns["Sefer ID"] != null)
                        dgvSeferler.Columns["Sefer ID"].Visible = false;
                }

                ResetSelection();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Uçuş aranırken hata: " + ex.Message);
            }
        }

        #endregion

        #region Koltuk Seçimi

        private void dgvSeferler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSeferler.Rows[e.RowIndex];
            _selectedTripId = Convert.ToInt32(row.Cells["Sefer ID"].Value);

            _ticketPrice = row.Cells["Fiyat (₺)"].Value != DBNull.Value
                ? Convert.ToDecimal(row.Cells["Fiyat (₺)"].Value)
                : Constants.DEFAULT_PRICE_PLANE;

            LoadSeats();
        }

        private void LoadSeats()
        {
            flpKoltuklar.Controls.Clear();
            _selectedSeatNo = -1;
            UpdatePriceLabels();

            _occupiedSeats = TicketService.GetOccupiedSeats(_selectedTripId);

            for (int i = 1; i <= Constants.SEAT_COUNT_PLANE; i++)
            {
                bool isOccupied = _occupiedSeats.Contains(i);
                var btnSeat = ThemeHelper.CreateSeatButton(i, isOccupied, 45);

                if (!isOccupied)
                {
                    btnSeat.Click += BtnSeat_Click;
                }

                flpKoltuklar.Controls.Add(btnSeat);
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            int seatNo = (int)clickedButton.Tag;

            foreach (Control ctrl in flpKoltuklar.Controls)
            {
                if (ctrl is Button btn && btn.Enabled)
                {
                    ThemeHelper.DeselectSeat(btn);
                }
            }

            ThemeHelper.SelectSeat(clickedButton);
            _selectedSeatNo = seatNo;

            UpdatePriceLabels();
        }

        private void UpdatePriceLabels()
        {
            lblSecilenKoltuk.Text = _selectedSeatNo > 0
                ? $"Seçilen Koltuk: {_selectedSeatNo}"
                : "Seçilen Koltuk: Yok";

            lblToplamFiyat.Text = _selectedSeatNo > 0
                ? $"Toplam: {_ticketPrice:N2} ₺"
                : "Toplam: 0.00 ₺";
        }

        private void ResetSelection()
        {
            flpKoltuklar.Controls.Clear();
            _selectedTripId = -1;
            _selectedSeatNo = -1;
            UpdatePriceLabels();
        }

        #endregion

        #region Satın Alma

        private void btnSatinAl_Click(object sender, EventArgs e)
        {
            if (_selectedTripId == -1)
            {
                MessageHelper.ShowWarning("Lütfen bir uçuş seçin.");
                return;
            }

            if (_selectedSeatNo == -1)
            {
                MessageHelper.ShowWarning("Lütfen bir koltuk seçin.");
                return;
            }

            var result = MessageHelper.ShowConfirm(
                $"Uçuş: {_selectedTripId}\nKoltuk: {_selectedSeatNo}\nFiyat: {_ticketPrice:N2} ₺\n\nSatın almak istiyor musunuz?",
                "Satın Alma Onayı");

            if (result == DialogResult.Yes)
            {
                PurchaseTicket();
            }
        }

        private void PurchaseTicket()
        {
            int startTerminalId = TicketService.GetTerminalIdByName(cmbKalkis.SelectedItem.ToString());
            int endTerminalId = TicketService.GetTerminalIdByName(cmbVaris.SelectedItem.ToString());

            bool success = TicketService.PurchaseTicket(
                _selectedTripId,
                _selectedSeatNo,
                startTerminalId,
                endTerminalId,
                _ticketPrice,
                "Yolcu",
                _userId > 0 ? (int?)_userId : null);

            if (success)
            {
                MessageHelper.ShowSuccess($"🎉 Uçak bileti başarıyla satın alındı!\n\nKoltuk No: {_selectedSeatNo}\nFiyat: {_ticketPrice:N2} ₺");
                LoadSeats();
            }
            else
            {
                MessageHelper.ShowError("Bilet satın alınırken hata oluştu.");
            }
        }

        #endregion
    }
}
