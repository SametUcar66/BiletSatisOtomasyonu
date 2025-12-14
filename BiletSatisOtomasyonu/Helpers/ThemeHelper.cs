using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Tema yardımcısı
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// DataGridView teması
        /// </summary>
        public static void ApplyDarkTheme(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;

            dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgv.ForeColor = Color.White;
            dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Constants.ColorPrimary;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
        }

        /// <summary>
        /// Koltuk butonu oluşturur
        /// </summary>
        public static Button CreateSeatButton(int seatNumber, bool isOccupied, int size = 45)
        {
            var btn = new Button
            {
                Text = seatNumber.ToString(),
                Size = new Size(size, size),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Tag = seatNumber,
                Margin = new Padding(3),
                BackColor = isOccupied ? Constants.ColorSeatOccupied : Constants.ColorSeatAvailable,
                ForeColor = Color.White,
                Enabled = !isOccupied
            };
            btn.FlatAppearance.BorderSize = 1;
            return btn;
        }

        /// <summary>
        /// Koltuk seçimi
        /// </summary>
        public static void SelectSeat(Button btn)
        {
            btn.BackColor = Constants.ColorSeatSelected;
        }

        /// <summary>
        /// Koltuk seçimini kaldır
        /// </summary>
        public static void DeselectSeat(Button btn)
        {
            if (btn.Enabled)
                btn.BackColor = Constants.ColorSeatAvailable;
        }
    }
}