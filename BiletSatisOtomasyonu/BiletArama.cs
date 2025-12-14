using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BiletSatisOtomasyonu.Helpers;
using BiletSatisOtomasyonu.Services;

namespace BiletSatisOtomasyonu
{
    public partial class BiletArama : UserControl
    {
        private int _selectedTripId = -1;
        private int _selectedSeatNo = -1;
        private decimal _ticketPrice = 0;
        private List<int> _occupiedSeats = new List<int>();
        private int _userId = 0;
        private string _currentVehicleType = null; // null = Tümü

        public BiletArama()
        {
            InitializeComponent();
        }

        public BiletArama(int userId) : this()
        {
            _userId = userId;
        }

        private void BiletArama_Load(object sender, EventArgs e)
        {
            SetupRadioButtons();
            SetupDatePicker();
            LoadAllTerminals();
            SearchAllTrips(); // Sayfa açıldığında tüm seferleri göster
            ThemeHelper.ApplyDarkTheme(dgvSeferler);
        }

        #region Araç Tipi Seçimi

        private void SetupRadioButtons()
        {
            rbTumu.Checked = true; // Varsayılan: Tümü
            rbTumu.CheckedChanged += RadioButton_CheckedChanged;
            rbUcak.CheckedChanged += RadioButton_CheckedChanged;
            rbOtobus.CheckedChanged += RadioButton_CheckedChanged;
            rbTren.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;

            if (rb == rbTumu)
            {
                _currentVehicleType = null;
                lblBaslik.Text = "🎫 Tüm Seferler";
                lblKalkis.Text = "Kalkış Noktası";
                lblVaris.Text = "Varış Noktası";
                LoadAllTerminals();
            }
            else if (rb == rbUcak)
            {
                _currentVehicleType = Constants.VEHICLE_TYPE_PLANE;
                lblBaslik.Text = "✈ Uçak Seferleri";
                lblKalkis.Text = "Kalkış Havalimanı";
                lblVaris.Text = "Varış Havalimanı";
                LoadTerminalsByType();
            }
            else if (rb == rbOtobus)
            {
                _currentVehicleType = Constants.VEHICLE_TYPE_BUS;
                lblBaslik.Text = "🚌 Otobüs Seferleri";
                lblKalkis.Text = "Kalkış Otogarı";
                lblVaris.Text = "Varış Otogarı";
                LoadTerminalsByType();
            }
            else if (rb == rbTren)
            {
                _currentVehicleType = Constants.VEHICLE_TYPE_TRAIN;
                lblBaslik.Text = "🚂 Tren Seferleri";
                lblKalkis.Text = "Kalkış Garı";
                lblVaris.Text = "Varış Garı";
                LoadTerminalsByType();
            }

            // Filtre değiştiğinde otomatik ara
            SearchTrips();
            ResetSelection();
        }

        #endregion

        #region Tarih Ayarları

        private void SetupDatePicker()
        {
            dtpTarih.MinDate = new DateTime(2025, 12, 1);
            dtpTarih.MaxDate = new DateTime(2025, 12, 31);
            dtpTarih.Value = new DateTime(2025, 12, 15);
        }

        #endregion

        #region Terminal Yükleme

        private void LoadAllTerminals()
        {
            try
            {
                var dt = TicketService.GetTerminals();
                FillTerminalComboBoxes(dt);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Terminal verileri yüklenirken hata: " + ex.Message);
            }
        }

        private void LoadTerminalsByType()
        {
            try
            {
                var dt = TicketService.GetTerminalsByType(_currentVehicleType);
                FillTerminalComboBoxes(dt);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Terminal verileri yüklenirken hata: " + ex.Message);
            }
        }

        private void FillTerminalComboBoxes(DataTable dt)
        {
            cmbKalkis.Items.Clear();
            cmbVaris.Items.Clear();

            cmbKalkis.Items.Add("-- Tümü --");
            cmbVaris.Items.Add("-- Tümü --");

            foreach (DataRow row in dt.Rows)
            {
                string terminalName = row["name"].ToString();
                cmbKalkis.Items.Add(terminalName);
                cmbVaris.Items.Add(terminalName);
            }

            cmbKalkis.SelectedIndex = 0;
            cmbVaris.SelectedIndex = 0;
        }

        #endregion

        #region Sefer Arama

        private void btnAra_Click(object sender, EventArgs e)
        {
            SearchTrips();
        }

        private void SearchAllTrips()
        {
            try
            {
                dgvSeferler.DataSource = null;

                DateTime selectedDate = dtpTarih.Value.Date;
                var dt = TicketService.SearchAllTrips(selectedDate);

                DisplayTrips(dt);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Seferler yüklenirken hata: " + ex.Message);
            }
        }

        private void SearchTrips()
        {
            try
            {
                dgvSeferler.DataSource = null;

                DateTime selectedDate = dtpTarih.Value.Date;
                
                string departure = cmbKalkis.SelectedIndex > 0 ? cmbKalkis.SelectedItem.ToString() : null;
                string arrival = cmbVaris.SelectedIndex > 0 ? cmbVaris.SelectedItem.ToString() : null;

                DataTable dt;

                if (_currentVehicleType == null)
                {
                    // Tüm araç tipleri
                    dt = TicketService.SearchAllTrips(selectedDate, departure, arrival);
                }
                else
                {
                    // Belirli araç tipi
                    dt = TicketService.SearchTrips(_currentVehicleType, selectedDate, departure, arrival);
                }

                DisplayTrips(dt);
                ResetSelection();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Sefer aranırken hata: " + ex.Message);
            }
        }

        private void DisplayTrips(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                dgvSeferler.DataSource = null;
            }
            else
            {
                dgvSeferler.DataSource = dt;

                if (dgvSeferler.Columns["Sefer ID"] != null)
                    dgvSeferler.Columns["Sefer ID"].Visible = false;
            }
        }

        #endregion

        #region Koltuk Seçimi

        private void dgvSeferler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSeferler.Rows[e.RowIndex];
            _selectedTripId = Convert.ToInt32(row.Cells["Sefer ID"].Value);

            // Araç tipini satırdan al
            string vehicleType = row.Cells["Araç Tipi"].Value?.ToString() ?? "";

            _ticketPrice = row.Cells["Fiyat (₺)"].Value != DBNull.Value
                ? Convert.ToDecimal(row.Cells["Fiyat (₺)"].Value)
                : GetDefaultPrice(vehicleType);

            LoadSeats(vehicleType);
        }

        private decimal GetDefaultPrice(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Uçak": return Constants.DEFAULT_PRICE_PLANE;
                case "Tren": return Constants.DEFAULT_PRICE_TRAIN;
                case "Otobüs": return Constants.DEFAULT_PRICE_BUS;
                default: return 500m;
            }
        }

        private int GetSeatCount(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Uçak": return Constants.SEAT_COUNT_PLANE;
                case "Tren": return Constants.SEAT_COUNT_TRAIN;
                case "Otobüs": return Constants.SEAT_COUNT_BUS;
                default: return 40;
            }
        }

        private void LoadSeats(string vehicleType)
        {
            flpKoltuklar.Controls.Clear();
            _selectedSeatNo = -1;
            UpdatePriceLabels();

            _occupiedSeats = TicketService.GetOccupiedSeats(_selectedTripId);

            int seatCount = GetSeatCount(vehicleType);
            int buttonSize = vehicleType == "Uçak" ? 45 : 40;

            for (int i = 1; i <= seatCount; i++)
            {
                bool isOccupied = _occupiedSeats.Contains(i);
                var btnSeat = ThemeHelper.CreateSeatButton(i, isOccupied, buttonSize);

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
                MessageHelper.ShowWarning("Lütfen bir sefer seçin.");
                return;
            }

            if (_selectedSeatNo == -1)
            {
                MessageHelper.ShowWarning("Lütfen bir koltuk seçin.");
                return;
            }

            // Seçilen satırdan araç tipini al
            string vehicleType = "";
            if (dgvSeferler.CurrentRow != null)
            {
                vehicleType = dgvSeferler.CurrentRow.Cells["Araç Tipi"].Value?.ToString() ?? "";
            }

            string vehicleIcon = GetVehicleIcon(vehicleType);
            var result = MessageHelper.ShowConfirm(
                $"{vehicleIcon} {vehicleType} Bileti\n\nSefer: {_selectedTripId}\nKoltuk: {_selectedSeatNo}\nFiyat: {_ticketPrice:N2} ₺\n\nSatın almak istiyor musunuz?",
                "Satın Alma Onayı");

            if (result == DialogResult.Yes)
            {
                PurchaseTicket();
            }
        }

        private string GetVehicleIcon(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Uçak": return "✈";
                case "Tren": return "🚂";
                case "Otobüs": return "🚌";
                default: return "🎫";
            }
        }

        private void PurchaseTicket()
        {
            string departure = cmbKalkis.SelectedIndex > 0 ? cmbKalkis.SelectedItem.ToString() : "";
            string arrival = cmbVaris.SelectedIndex > 0 ? cmbVaris.SelectedItem.ToString() : "";

            int startTerminalId = !string.IsNullOrEmpty(departure) ? TicketService.GetTerminalIdByName(departure) : 0;
            int endTerminalId = !string.IsNullOrEmpty(arrival) ? TicketService.GetTerminalIdByName(arrival) : 0;

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
                string vehicleType = dgvSeferler.CurrentRow?.Cells["Araç Tipi"].Value?.ToString() ?? "Bilet";
                MessageHelper.ShowSuccess($"🎉 {vehicleType} bileti başarıyla satın alındı!\n\nKoltuk No: {_selectedSeatNo}\nFiyat: {_ticketPrice:N2} ₺");
                
                // Koltukları yenile
                LoadSeats(vehicleType);
            }
            else
            {
                MessageHelper.ShowError("Bilet satın alınırken hata oluştu.");
            }
        }

        #endregion
    }
}