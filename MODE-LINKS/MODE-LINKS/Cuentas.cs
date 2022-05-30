using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODE_LINKS
{
    public partial class Cuentas : Form
    {
        Cuenta cuenta = new Cuenta();
        Principal principal = new Principal();

        //PARA MARCAS DE AGUA
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public Cuentas()
        {
            InitializeComponent();
            
            //MARCAS DE AGUA EN TEXTBOXS
            SendMessage(txbIDTecnico.Handle, EM_SETCUEBANNER, 10, " ID Usuario");
            SendMessage(txbDni.Handle, EM_SETCUEBANNER, 10, " DNI");
            SendMessage(txbNombre.Handle, EM_SETCUEBANNER, 10, " Nombre");
            SendMessage(txbApellido1.Handle, EM_SETCUEBANNER, 10, " Primer Apellido");
            SendMessage(txbApellido2.Handle, EM_SETCUEBANNER, 10, " Segundo Apellido");
            SendMessage(txbTelefono.Handle, EM_SETCUEBANNER, 10, " Telefono");
            SendMessage(txbEmail.Handle, EM_SETCUEBANNER, 10, " Email");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            SendMessage(txbTipoUsuario.Handle, EM_SETCUEBANNER, 10, " Tipo de Usuario");
            SendMessage(txbIDVehiculo.Handle, EM_SETCUEBANNER, 10, " Vehiculo Asignado");
            SendMessage(txbImagen.Handle, EM_SETCUEBANNER, 10, " URL Imagen");
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            dataGridViewCuentas.DataSource = cuenta.conexionConLaTabla();
        }

        private void dataGridViewCuentas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = cuenta.conexionConLaTabla();
                txbIDTecnico.Text = dt.Rows[e.RowIndex][0].ToString();
                txbDni.Text = dt.Rows[e.RowIndex][1].ToString();
                txbNombre.Text = dt.Rows[e.RowIndex][2].ToString();
                txbApellido1.Text = dt.Rows[e.RowIndex][3].ToString();
                txbApellido2.Text = dt.Rows[e.RowIndex][4].ToString();
                txbTelefono.Text = dt.Rows[e.RowIndex][5].ToString();
                txbEmail.Text = dt.Rows[e.RowIndex][6].ToString();
                txbContrasenya.Text = dt.Rows[e.RowIndex][7].ToString();
                txbTipoUsuario.Text = dt.Rows[e.RowIndex][8].ToString();
                txbIDVehiculo.Text = dt.Rows[e.RowIndex][9].ToString();
                txbImagen.Text = dt.Rows[e.RowIndex][10].ToString();
                txbIDTecnico.Enabled = false;
                if (txbImagen.Text == "")
                {
                    pictureBox1Usuario.Image = new Bitmap(@"C:\Users\josem\OneDrive\Escritorio\FCT\MODE-LINKS\MODE-LINKS\Resources\usuario (3).png");
                }
                else
                {
                    pictureBox1Usuario.Image = new Bitmap(txbImagen.Text);
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnModificarCuenta_Click(object sender, EventArgs e)
        {
            cuenta.id_tecnico = txbIDTecnico.Text;
            cuenta.dni = txbDni.Text;
            cuenta.nombre = txbNombre.Text;
            cuenta.apellido1 = txbApellido1.Text;
            cuenta.apellido2 = txbApellido2.Text;
            cuenta.telefono = txbTelefono.Text;
            cuenta.email = txbEmail.Text;
            cuenta.contrasenya = txbContrasenya.Text;
            cuenta.tipo_usuario = txbTipoUsuario.Text;
            cuenta.id_vehiculo = txbIDVehiculo.Text;
            cuenta.imagen = txbImagen.Text;
            principal.cambiarImagen(txbImagen.Text);
            cuenta.modificarCuenta(cuenta);
            refrescarTabla();
            limpiarPantalla();
        }


        private void refrescarTabla()
        {
            dataGridViewCuentas.DataSource = cuenta.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            txbIDTecnico.Text = "";
            txbDni.Text = "";
            txbNombre.Text = "";
            txbApellido1.Text = "";
            txbApellido2.Text = "";
            txbTelefono.Text = "";
            txbEmail.Text = "";
            txbContrasenya.Text = "";
            txbTipoUsuario.Text = "";
            txbIDVehiculo.Text = "";
            txbImagen.Text = "";
            pictureBox1Usuario.Image = new Bitmap(@"C:\Users\josem\OneDrive\Escritorio\FCT\MODE-LINKS\MODE-LINKS\Resources\usuario (3).png");
        }

        private void btnSeleccionarImagen_Click_1(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                txbImagen.Text = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(txbImagen.Text);
                    size = text.Length;
                    pictureBox1Usuario.Image = new Bitmap(txbImagen.Text);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Console.WriteLine(size); 
            Console.WriteLine(result); 
        }
    }
}
