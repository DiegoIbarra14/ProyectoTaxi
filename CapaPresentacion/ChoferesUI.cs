
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
using System.Text.RegularExpressions;

namespace CapaPresentacion
{
    public partial class ChoferesUI : Form
    {
        private Label[] labels;
        private Label mensajeErrorLabel;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public ChoferesUI()
        {

            InitializeComponent();
      
            txtNombreC.Validating += TextBox_Validating;
            txtApellidoP.Validating += TextBox_Validating;
            txtApellidoM.Validating += TextBox_Validating;

            


        }
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            RJCodeAdvance.RJControls.RJTextBox textBox = sender as RJCodeAdvance.RJControls.RJTextBox;
            string cadena=textBox.Texts;
            string patron = "^[a-zA-Z]+[a-zA-Z ]?$";
            // Verifica si textBox no es nulo y si su Text está vacío o contiene solo espacios en blanco
            if (!Regex.IsMatch(cadena,patron))
            { 
                e.Cancel = false;
                MostrarMensajeError(textBox, "Datos Invalidos");
            }
            else
            {
               e.Cancel= false;
                OcultarMensajeError(textBox);
            }
        }

        // Método para mostrar un mensaje de error debajo del TextBox
        private void MostrarMensajeError(RJCodeAdvance.RJControls.RJTextBox textBox, string mensaje)
        {
            // Crea un nuevo Label para mostrar el mensaje de error
            Label errorLabel = new Label
            {
                Text = mensaje,
                ForeColor = System.Drawing.Color.Red,
                Location = new System.Drawing.Point(144, textBox.Location.Y+30),
                AutoSize = true,
                
            };

            // Agrega el Label al formulario
            this.panel1.Controls.Add(errorLabel);
        }

        // Método para ocultar el mensaje de error
        private void OcultarMensajeError(RJCodeAdvance.RJControls.RJTextBox textBox)
        {
            // Recorre todos los controles del formulario y elimina los Label de mensajes de error
            List<Control> controlesAEliminar = new List<Control>();

            foreach (Control control in this.panel1.Controls)
            {
                if (control is Label && control.Location.Y == textBox.Location.Y + 30)
                {
                    controlesAEliminar.Add(control);
                }
            }

            foreach (Control controlAEliminar in controlesAEliminar)
            {
                this.panel1.Controls.Remove(controlAEliminar);
            }
        }

        private void ChoferesUI_Load(object sender, EventArgs e)
        {
            //this.table.DataSource=new ChoferBLL().SelectAll();
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void rjDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        private void txtNombreC__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
        }
    }
}
