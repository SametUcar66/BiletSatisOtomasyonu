using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BiletSatisOtomasyonu
{
    public partial class SPManager : Form
    {
        private SQLiteConnection baglan = new SQLiteConnection("Data Source=BiletSatis.db; Version=3");

        private readonly Dictionary<string, string> tablolar = new Dictionary<string, string>
        {
            { "Kullanıcılar", "users" },
            { "Acentalar", "agencies" },
            { "Roller", "roles" },
            { "Seferler", "trips" },
            { "Biletler", "tickets" },
            { "Araçlar", "vehicles" },
            { "Araç Tipleri", "vehicle_types" },
            { "Araç Üniteleri", "vehicle_units" },
            { "Rotalar", "routes" },
            { "Rota Durakları", "route_stops" },
            { "Terminaller", "terminals" },
            { "Koltuklar", "seats" },
            { "Sefer Giderleri", "trip_expenses" }
        };

        public SPManager()
        {
            InitializeComponent();
        }

        private void SPManager_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            SetupDataGridView();
        }

        #region Başlangıç Ayarları

        private void LoadComboBox()
        {
            cmbTableSelect.Items.Clear();
            cmbTableSelect.Items.Add("-- Tablo Seçin --");

            foreach (var tablo in tablolar)
            {
                cmbTableSelect.Items.Add(tablo.Key);
            }

            cmbTableSelect.SelectedIndex = 0;
            cmbTableSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTableSelect.SelectedIndexChanged += cmbTableSelect_SelectedIndexChanged;
        }

        private void SetupDataGridView()
        {
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.ReadOnly = true;
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
        }

        #endregion

        #region Veri İşlemleri

        private void cmbTableSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTableSelect.SelectedIndex <= 0)
            {
                dgvData.DataSource = null;
                return;
            }

            string selectedKey = cmbTableSelect.SelectedItem.ToString();

            if (tablolar.ContainsKey(selectedKey))
            {
                string tableName = tablolar[selectedKey];
                LoadTableData(tableName);
            }
        }

        private void LoadTableData(string tableName)
        {
            try
            {
                baglan.Open();

                string query = $"SELECT * FROM {tableName}";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, baglan);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglan.Close();
            }
        }

        #endregion
    }
}
