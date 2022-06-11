using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODE_LINKS
{
    public partial class Tecnicos : Form
    {
        Tecnico tecnico = new Tecnico();

        //PARA PARCAS DE AGUA DE LOS TEXTBOX
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
        public Tecnicos()
        {
            InitializeComponent();

            //MARCAS DE AGUA DE LOS TEXTBOX
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbIDTecnico.Handle, EM_SETCUEBANNER, 10, " ID Técnico");
            SendMessage(txbDni.Handle, EM_SETCUEBANNER, 10, " DNI");
            SendMessage(txbNombre.Handle, EM_SETCUEBANNER, 10, " Nombre");
            SendMessage(txbApellido1.Handle, EM_SETCUEBANNER, 10, " Primer Apellido");
            SendMessage(txbApellido2.Handle, EM_SETCUEBANNER, 10, " Segundo Apellido");
            SendMessage(txbTelefono.Handle, EM_SETCUEBANNER, 10, " Telefono");
            SendMessage(txbEmail.Handle, EM_SETCUEBANNER, 10, " Email");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            SendMessage(txbTipoUsuario.Handle, EM_SETCUEBANNER, 10, " Tipo de Usuario");
            SendMessage(txbIDVehiculo.Handle, EM_SETCUEBANNER, 10, " Vehiculo Asignado");
        }

        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        private void Tecnicos_Load(object sender, EventArgs e)
        {
            dataGridViewTecnicos.DataSource = tecnico.conexionConLaTabla();
        }

        private void dataGridViewTecnicos_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = tecnico.conexionConLaTabla();
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
                txbIDTecnico.Enabled = false;
                btnAnyadirTecnico.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnAnyadirTecnico_Click(object sender, EventArgs e)
        {
            Regex validacionDNI = new Regex("^[0-9]{8}[A-Z]{1}$");
            Regex validacionCorreo = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$");
            Regex validacionTelefono = new Regex("^[0-9]{9}$");
            if (validacionDNI.IsMatch(txbDni.Text))
            {
                tecnico.dni = txbDni.Text;
            }
            else
            {
                MessageBox.Show("El formato del DNI tiene que ser de 8 numeros y una letra.");
            }
            tecnico.nombre = txbNombre.Text;
            tecnico.apellido1 = txbApellido1.Text;
            tecnico.apellido2 = txbApellido2.Text;
            if(validacionTelefono.IsMatch(txbTelefono.Text))
            {
                tecnico.telefono = txbTelefono.Text;
            }
            else
            {
                MessageBox.Show("El formato del teléfono no es correcto.");
            }
            if (validacionCorreo.IsMatch(txbEmail.Text))
            {
                tecnico.email = txbEmail.Text;
            }
            else
            {
                MessageBox.Show("El formato del email no es correcto.");
            }
            tecnico.contrasenya = txbContrasenya.Text;
            tecnico.tipo_usuario = txbTipoUsuario.Text;
            tecnico.id_vehiculo = txbIDVehiculo.Text;
            tecnico.imagen = "";
            tecnico.agregarTecnico(tecnico);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnModificarTecnico_Click(object sender, EventArgs e)
        {
            Regex validacionDNI = new Regex("^[0-9]{8}[A-Z]{1}$");
            Regex validacionCorreo = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:.[a-zA-Z0-9-]+)*$");
            Regex validacionTelefono = new Regex("^[0-9]{9}$");
            tecnico.id_tecnico = txbIDTecnico.Text;
            if (validacionDNI.IsMatch(txbDni.Text))
            {
                tecnico.dni = txbDni.Text;
            }
            else
            {
                MessageBox.Show("El formato del DNI tiene que ser de 8 numeros y una letra.");
            }
            tecnico.nombre = txbNombre.Text;
            tecnico.apellido1 = txbApellido1.Text;
            tecnico.apellido2 = txbApellido2.Text;
            if (validacionTelefono.IsMatch(txbTelefono.Text))
            {
                tecnico.telefono = txbTelefono.Text;
            }
            else
            {
                MessageBox.Show("El formato del teléfono no es correcto.");
            }
            if (validacionCorreo.IsMatch(txbEmail.Text))
            {
                tecnico.email = txbEmail.Text;
            }
            else
            {
                MessageBox.Show("El formato del email no es correcto.");
            }
            tecnico.contrasenya = txbContrasenya.Text;
            tecnico.tipo_usuario = txbTipoUsuario.Text;
            tecnico.id_vehiculo = txbIDVehiculo.Text;
            tecnico.imagen = "";
            tecnico.modificarTecnico(tecnico);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnEliminarTecnico_Click(object sender, EventArgs e)
        {
            tecnico.id_tecnico = txbIDTecnico.Text;
            tecnico.eliminarTecnico(tecnico);
            refrescarTabla();
            limpiarPantalla();
        }

        private void refrescarTabla()
        {
            dataGridViewTecnicos.DataSource = tecnico.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            btnAnyadirTecnico.Enabled = true;
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
        }
    }
}
