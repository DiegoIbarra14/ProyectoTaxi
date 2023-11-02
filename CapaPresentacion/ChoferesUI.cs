using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio;
namespace CapaPresentacion
{
    public partial class ChoferesUI : Form
    {
        public ChoferesUI()
        {
            InitializeComponent();
        }

        private void ChoferesUI_Load(object sender, EventArgs e)
        {
            this.table.DataSource=new ChoferBLL().SelectAll();
        }
    }
}
