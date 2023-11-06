using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class HospitalIU : Form
    {
        public HospitalIU()
        {
            InitializeComponent();
        }

        private void HospitalIU_Load(object sender, EventArgs e)
        {
            FillGrid();
            AddIcon();
        }
        private void FillGrid()
        {
            this.table.DataSource = new HospitalBLL().SelectAll();

        }
        private void AddIcon()
        {
            DataGridViewLinkColumn columnalinkEdit = new DataGridViewLinkColumn();
            columnalinkEdit.HeaderText = "";
            columnalinkEdit.Text = "🖋️";
            columnalinkEdit.FillWeight = 20;
            columnalinkEdit.UseColumnTextForLinkValue = true;
            this.table.Columns.Add(columnalinkEdit);
            DataGridViewLinkColumn columnalinkDelete = new DataGridViewLinkColumn();
            columnalinkDelete.HeaderText = "";
            columnalinkDelete.Text = "🗑️";
            columnalinkDelete.LinkColor = Color.Red;
            columnalinkDelete.FillWeight = 20;
            columnalinkDelete.UseColumnTextForLinkValue = true;
            this.table.Columns.Add(columnalinkDelete);

        }
    }
}
