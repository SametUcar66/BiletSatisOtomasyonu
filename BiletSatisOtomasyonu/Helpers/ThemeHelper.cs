using System.Drawing;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu.Helpers
{
    /// <summary>
    /// Tema ve stil yardımcı sınıfı
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// DataGridView'e koyu tema uygular
        /// </summary>
        public static void ApplyDarkTheme(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            dgv.BackgroundColor = Constants.ColorBackgroundDark;
            dgv.ForeColor = Color.White;
            dgv.GridColor = Constants.ColorBackgroundLight;
            dgv.DefaultCellStyle.BackColor = Constants.ColorBackgroundMedium;
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Constants.ColorPrimary;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Constants.ColorBackgroundLight;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
        }

        /// <summary>
        /// Koltuk butonu oluşturur
        /// </summary>
        public static Button CreateSeatButton(int seatNumber, bool isOccupied, int size = 50)
        {
            var btn = new Button
            {
                Name = "btnKoltuk" + seatNumber,
                Text = seatNumber.ToString(),
                Size = new Size(size, size),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Tag = seatNumber,
                Margin = new Padding(5)
            };

            btn.FlatAppearance.BorderSize = 1;

            if (isOccupied)
            {
                btn.BackColor = Constants.ColorSeatOccupied;
                btn.ForeColor = Color.White;
                btn.Enabled = false;
            }
            else
            {
                btn.BackColor = Constants.ColorSeatAvailable;
                btn.ForeColor = Color.White;
            }

            return btn;
        }

        /// <summary>
        /// Koltuk seçim rengini günceller
        /// </summary>
        public static void SelectSeat(Button button)
        {
            button.BackColor = Constants.ColorSeatSelected;
        }

        /// <summary>
        /// Koltuk seçimini kaldırır
        /// </summary>
        public static void DeselectSeat(Button button)
        {
            if (button.Enabled)
            {
                button.BackColor = Constants.ColorSeatAvailable;
            }
        }

        /// <summary>
        /// TextBox'a inaktif stil uygular
        /// </summary>
        public static void SetTextBoxInactive(TextBox textBox)
        {
            textBox.ForeColor = Constants.ColorTextInactive;
            textBox.BackColor = Color.FromArgb(45, 45, 60);
        }

        /// <summary>
        /// TextBox'a aktif stil uygular
        /// </summary>
        public static void SetTextBoxActive(TextBox textBox)
        {
            textBox.ForeColor = Constants.ColorTextActive;
            textBox.BackColor = Color.FromArgb(60, 60, 80);
        }
    }
}