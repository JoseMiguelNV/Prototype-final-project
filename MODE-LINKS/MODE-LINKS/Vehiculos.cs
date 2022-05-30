using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODE_LINKS
{
    public partial class Vehiculos : Form
    {
        Vehiculo vehiculo = new Vehiculo();

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
        public Vehiculos()
        {
            InitializeComponent();
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbIDVehiculo.Handle, EM_SETCUEBANNER, 10, " ID Vehiculo");
            SendMessage(txbMatricula.Handle, EM_SETCUEBANNER, 10, " Matricula");
            SendMessage(txbMarca.Handle, EM_SETCUEBANNER, 10, " Marca");
            SendMessage(txbModelo.Handle, EM_SETCUEBANNER, 10, " Modelo");
            SendMessage(txbEntrada.Handle, EM_SETCUEBANNER, 10, " Fecha de Entrada");
            SendMessage(txbSalida.Handle, EM_SETCUEBANNER, 10, " Fecha de Salida");
            SendMessage(txbIDMulta.Handle, EM_SETCUEBANNER, 10, " ID Multa");
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

        private void Vehiculos_Load(object sender, EventArgs e)
        {
            dataGridViewVehiculos.DataSource = vehiculo.conexionConLaTabla();
        }

        private void dataGridViewVehiculos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = vehiculo.conexionConLaTabla();
                txbIDVehiculo.Text = dt.Rows[e.RowIndex][0].ToString();
                txbMatricula.Text = dt.Rows[e.RowIndex][1].ToString();
                txbMarca.Text = dt.Rows[e.RowIndex][2].ToString();
                txbModelo.Text = dt.Rows[e.RowIndex][3].ToString();
                txbEntrada.Text = dt.Rows[e.RowIndex][4].ToString();
                txbSalida.Text = dt.Rows[e.RowIndex][5].ToString();
                txbIDMulta.Text = dt.Rows[e.RowIndex][6].ToString();
                txbIDVehiculo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnAnyadirVehículo_Click(object sender, EventArgs e)
        {
            vehiculo.matricula = txbMatricula.Text;
            vehiculo.marca = txbMarca.Text;
            vehiculo.modelo = txbModelo.Text;
            vehiculo.entrada = txbEntrada.Text;
            vehiculo.salida = txbSalida.Text;
            vehiculo.id_multa = txbIDMulta.Text;
            vehiculo.agregarVehiculo(vehiculo);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnModificarVehículo_Click(object sender, EventArgs e)
        {
            vehiculo.id_vehiculo = txbIDVehiculo.Text;
            vehiculo.matricula = txbMatricula.Text;
            vehiculo.marca = txbMarca.Text;
            vehiculo.modelo = txbModelo.Text;
            vehiculo.entrada = txbEntrada.Text;
            vehiculo.salida = txbSalida.Text;
            vehiculo.id_multa = txbIDMulta.Text;
            vehiculo.modificarVehiculo(vehiculo);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnEliminarTecnico_Click(object sender, EventArgs e)
        {
            vehiculo.id_vehiculo = txbIDVehiculo.Text;
            vehiculo.eliminarVehiculo(vehiculo);
            refrescarTabla();
            limpiarPantalla();
        }

        private void refrescarTabla()
        {
            dataGridViewVehiculos.DataSource = vehiculo.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            txbIDVehiculo.Text = "";
            txbMatricula.Text = "";
            txbMarca.Text = "";
            txbModelo.Text = "";
            txbEntrada.Text = "";
            txbSalida.Text = "";
            txbIDMulta.Text = "";
        }
    }
}
