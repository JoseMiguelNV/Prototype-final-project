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
    public partial class Trabajos : Form
    {
        Trabajo trabajo = new Trabajo();

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
        public Trabajos()
        {
            InitializeComponent();
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbIDTrabajo.Handle, EM_SETCUEBANNER, 10, " ID Trabajo");
            SendMessage(txbIDTecnico.Handle, EM_SETCUEBANNER, 10, " ID Tecnico");
            SendMessage(txbIDVehiculo.Handle, EM_SETCUEBANNER, 10, " Vehiculo Asignado");
            SendMessage(txbIDProyecto.Handle, EM_SETCUEBANNER, 10, " ID Proyecto");
            SendMessage(txbDescripcion.Handle, EM_SETCUEBANNER, 10, " Descripcion del Trabajo");  
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
        private void Trabajos_Load(object sender, EventArgs e)
        {
            dataGridViewTrabajos.DataSource = trabajo.conexionConLaTabla();
        }

        private void dataGridViewTrabajos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = trabajo.conexionConLaTabla();
                txbIDTrabajo.Text = dt.Rows[e.RowIndex][0].ToString();
                txbIDTecnico.Text = dt.Rows[e.RowIndex][1].ToString();
                txbIDVehiculo.Text = dt.Rows[e.RowIndex][5].ToString();
                txbIDProyecto.Text = dt.Rows[e.RowIndex][8].ToString();
                txbDescripcion.Text = dt.Rows[e.RowIndex][10].ToString();
                txbIDTrabajo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnAnyadirTrabajo_Click(object sender, EventArgs e)
        {
            trabajo.id_tecnico = txbIDTecnico.Text;
            trabajo.id_vehiculo = txbIDVehiculo.Text;
            trabajo.id_proyecto = txbIDProyecto.Text;
            trabajo.descripcion = txbDescripcion.Text;
            trabajo.agregarTrabajo(trabajo);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnModificarTrabajo_Click(object sender, EventArgs e)
        {
            trabajo.id_trabajo = txbIDTrabajo.Text;
            trabajo.id_tecnico = txbIDTecnico.Text;
            trabajo.id_vehiculo = txbIDVehiculo.Text;
            trabajo.id_proyecto = txbIDProyecto.Text;
            trabajo.descripcion = txbDescripcion.Text;
            trabajo.modificarTrabajo(trabajo);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnEliminarTrabajo_Click(object sender, EventArgs e)
        {
            trabajo.id_trabajo = txbIDTrabajo.Text;
            trabajo.eliminarTrabajo(trabajo);
            refrescarTabla();
            limpiarPantalla();
        }

        private void refrescarTabla()
        {
            dataGridViewTrabajos.DataSource = trabajo.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            txbIDTrabajo.Text = "";
            txbIDTecnico.Text = "";
            txbIDVehiculo.Text = "";
            txbIDProyecto.Text = "";
            txbDescripcion.Text = "";
        }
    }
}
