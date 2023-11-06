
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
using CapaEntidad;
using System.Net;
using System.Windows.Media.Media3D;

namespace CapaPresentacion
{
    public partial class ChoferesUI : Form
    {
        public string dniSelected;
        private int opcion=1;
        private Label[] labels;
        private Label mensajeErrorLabel;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private bool verificar=false;
        public static int ParentX,ParentY;
       
        private DataTable tablaDatos; 
        private DataTable tablaFiltrada;

        public ChoferesUI()
        {

            InitializeComponent();
      
            txtNombreC.Validating += TextBox_Validating;
            txtApellidoP.Validating += TextBox_Validating;
            txtApellidoM.Validating += TextBox_Validating;
            txtdni.Validating+= TextBox_ValidatingDNI;
           

        }
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            RJCodeAdvance.RJControls.RJTextBox textBox = sender as RJCodeAdvance.RJControls.RJTextBox;
            string cadena=textBox.Texts;
            string patron = "^[a-zA-Z]+[a-zA-Z ]?$";
            // Verifica si textBox no es nulo y si su Text está vacío o contiene solo espacios en blanco
            if (!Regex.IsMatch(cadena,patron))
            {
                verificar = false;
                MostrarMensajeError(textBox, "Datos Invalidos");
            }
            else
            {
                verificar=true;
                OcultarMensajeError(textBox);
            }
        }
       

        private void TextBox_ValidatingDNI(object sender, CancelEventArgs e)
        {
            RJCodeAdvance.RJControls.RJTextBox textBox = sender as RJCodeAdvance.RJControls.RJTextBox;
            string cadena = textBox.Texts;
            string patron = "^\\d{8}$";
            if (!textBox.Enabled) {
                return;
            }
            else
            {
                if (!Regex.IsMatch(cadena, patron))
                {
                    verificar = false;
                    MostrarMensajeError(textBox, "Datos Invalidos");
                }
                else
                {
                    verificar = true;
                    OcultarMensajeError(textBox);
                }

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
            FillGrid();
            FillPlacas();
            AddIcon();

        }
        private void AddIcon (){
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
        private void FillGrid() {

            this.tablaDatos = new ChoferBLL().SelectAll();
            this.table.DataSource = new ChoferBLL().SelectAll();
            



        }
        public void FillPlacas() {
            this.txtPlaca.Items.AddRange(new VehiculoBLL().select().ToArray());
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda hace clic y es la columna de enlace
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && table.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                if (e.ColumnIndex == 2)
                {
                    this.verificar = true;
                    lblCrudMode.Text = "Editar Chofer";
                    this.opcion = 2;
                    txtdni.Enabled = false;
                    txtNombreC.Texts = table.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    string apellidos = table.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                    string[] partesApellido = apellidos.Split(' ');
                    txtApellidoP.Texts = partesApellido[0];
                    txtApellidoM.Texts = partesApellido[1];
                    txtdni.Texts = table.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                    this.panel1.Visible = true;
                    txtPlaca.SelectedItem = table.Rows[e.RowIndex].Cells["placa"].Value;
                    DateTime fechaCompleta = DateTime.ParseExact(table.Rows[e.RowIndex].Cells["Fecha de Ingreso"].Value.ToString(), "d/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    txtFechaI.Value = fechaCompleta.Date;
                    

                }
                else {
                    this.dniSelected= table.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                    
                    Form modalback = new Form();
                    using (Modal modal = new Modal())
                    {
                        modal.operacion = Eliminar;
                        modalback.StartPosition = FormStartPosition.Manual;
                        modalback.Opacity = 0.50d;
                        modalback.BackColor = Color.Black;
                        modalback.FormBorderStyle = FormBorderStyle.None;
                        modalback.Size = this.Parent.Size;
                        modalback.ShowInTaskbar = false;
                        modalback.Location = this.PointToScreen(Point.Empty) ;

                        modalback.Show();
                        modal.Owner = modalback;
                        
                       
                        modal.ShowDialog();
                        modalback.Dispose();




                        };

                    }






            }
        }
        public void Eliminar()
        {
            //MessageBox.Show(dniSelected)
            ChoferBLL choferBLL = new ChoferBLL();
            ChoferEL choferEL = new ChoferEL();
            choferEL.Dni = dniSelected;
            int resultado = choferBLL.Delete(choferEL);
            if (resultado == 1)
            {
                FillGrid();
                this.snackm.Show(this.ParentForm, "Registro Eliminado Correctamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
            }
            else {
                this.snackm.Show(this.ParentForm, "Hubo un error al elimina registro", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
           


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
            lblCrudMode.Text = "Añadir Chofer";
            limpiartext();
            this.txtdni.Enabled = true;
            this.panel1.Visible = true;
            
        }

        private void comboPlaca_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (this.opcion)
            {
                case 1:
                    Insert();
                    break;
                case 2:
                    Actualizar();
                    break;

            }
            
           
            
        }

        public void Insert()
        {
            if (this.verificar && !string.IsNullOrEmpty(txtNombreC.Texts)&& !string.IsNullOrEmpty(txtApellidoP.Texts) && !string.IsNullOrEmpty(txtApellidoM.Texts) && !string.IsNullOrEmpty(txtdni.Texts) && txtPlaca.SelectedItem != null && !string.IsNullOrEmpty(txtPlaca.SelectedItem.ToString()))
            {
                string nombre, apellidoP, apellidoM, dni;
                DateTime fecha;
                dni = txtdni.Texts;
                apellidoP = txtApellidoP.Texts;
                apellidoM = txtApellidoM.Texts;
                nombre = txtNombreC.Texts;
                fecha = txtFechaI.Value;
                object placa = txtPlaca.SelectedItem;


                ChoferEL choferEL = new ChoferEL();
                choferEL.Dni = dni;
                choferEL.Nombre = nombre;
                choferEL.Placa = placa.ToString();
                choferEL.ApellidoP = apellidoP;
                choferEL.ApellidoM = apellidoM;
                choferEL.Ingreso = fecha;
                string resultado = new ChoferBLL().Insert(choferEL);
                this.snackm.Show(this.ParentForm, "Datos Registrados Correctamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                FillGrid();
               
                this.opcion = 1;
            }
            else
            {
                this.snackm.Show(this.ParentForm, "Rellenar todos los campos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
                //MessageBox.Show(this.verificar.ToString());
                //MessageBox.Show(string.IsNullOrEmpty(txtNombreC.Texts).ToString());
                //MessageBox.Show(string.IsNullOrEmpty(txtApellidoP.Texts).ToString());
                //MessageBox.Show(string.IsNullOrEmpty(txtApellidoM.Texts).ToString());
                //MessageBox.Show(string.IsNullOrEmpty(txtdni.Texts).ToString());
             

            }
        }
        public void Actualizar() {

            if (this.verificar && txtPlaca.SelectedItem != null && !string.IsNullOrEmpty(txtPlaca.SelectedItem.ToString()))
            {
                string nombre, apellidoP, apellidoM, dni;
                DateTime fecha;
                dni = txtdni.Texts;
                apellidoP = txtApellidoP.Texts;
                apellidoM = txtApellidoM.Texts;
                nombre = txtNombreC.Texts;
                fecha = txtFechaI.Value;
                object placa = txtPlaca.SelectedItem;


                ChoferEL choferEL = new ChoferEL();
                choferEL.Dni = dni;
                choferEL.Nombre = nombre;
                choferEL.Placa = placa.ToString();
                choferEL.ApellidoP = apellidoP;
                choferEL.ApellidoM = apellidoM;
                choferEL.Ingreso = fecha;
                new ChoferBLL().Update(choferEL);
                this.snackm.Show(this.ParentForm, "Datos Actualizados Correctamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success);
                FillGrid();
                this.limpiartext();
                this.panel1.Visible=false;
            }
            else
            {
                

                this.snackm.Show(this.ParentForm, "Rellenar correctamente todos los campos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error);
            }
        }
       
        private void filtarDatos(object sender, EventArgs e)
        {
            
            TextBox miTextBox = (TextBox)sender;
            DataView vista = tablaDatos.DefaultView;


            // Aplica el filtro solo si el texto no está vacío
            if (!string.IsNullOrEmpty(miTextBox.Text))
            {
                vista.RowFilter = $"Nombre LIKE '%{miTextBox.Text}%'";
            }
            else
            {
                vista.RowFilter = string.Empty;
            }

        }

        public void limpiartext() {
            txtdni.Texts="";
            txtApellidoP.Texts = "";
            txtApellidoM.Texts = "";
            txtNombreC.Texts = "";
            txtFechaI.Value= DateTime.Now;
            txtPlaca.SelectedIndex = -1;
            this.txtFiltro.Texts = "";  




        }
    }
}
