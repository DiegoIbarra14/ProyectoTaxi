using CapaEntidad;
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
    // Declarar el delegado a nivel de espacio de nombres
    public delegate void CapaPresentacionDelegate();

    // Resto del código del espacio de nombres...
}

namespace CapaPresentacion
{

    

    public partial class Modal : Form
    {
        public CapaPresentacionDelegate operacion;
        public Modal( )
        {
            InitializeComponent();
        }

        private void lblModalTitle_Click(object sender, EventArgs e)
        {

        }

        private void Modal_Load(object sender, EventArgs e)
        {
          //this.Location=new Point(ChoferesUI.ParentX, ChoferesUI.ParentY);
        }

      

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.operacion();
            

        }
        

        
       
    }
}
