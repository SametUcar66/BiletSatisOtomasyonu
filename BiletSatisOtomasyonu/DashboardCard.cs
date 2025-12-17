using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiletSatisOtomasyonu
{
    public partial class DashboardCard : UserControl
    {
        public DashboardCard()
        {
            InitializeComponent();
        }
        public event EventHandler ManageClicked;

        public int UserTypeID { get; set; }
        public void SetData(string title, int count, Color color, int userType)
        {
            lblTitle.Text = title;
            lblCount.Text = count.ToString();
            pnlColorStrip.BackColor = color;
            lblCount.ForeColor = color;
            this.UserTypeID = userType;
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            // Eğer abone olan varsa olayı tetikle
            ManageClicked?.Invoke(this, e);
        }
    }
}
