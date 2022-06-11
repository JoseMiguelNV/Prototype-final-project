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
    public partial class Herramientas : Form
    {
        Herramienta herramienta = new Herramienta();

        //PARA MARCAS DE AGUA DE LOS TEXTBOX
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
        public Herramientas()
        {
            InitializeComponent();

            //MARCAS DE AGUA DE LOS TEXTBOX
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbIDHerramienta.Handle, EM_SETCUEBANNER, 10, " ID Herramienta");
            SendMessage(txbCodigoHerramienta.Handle, EM_SETCUEBANNER, 10, " Codigo");
            SendMessage(txbMarcaHerramienta.Handle, EM_SETCUEBANNER, 10, " Marca");
            SendMessage(txbTipoHerramienta.Handle, EM_SETCUEBANNER, 10, " Tipo de herramienta");
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

        private void Herramientas_Load(object sender, EventArgs e)
        {
            dataGridViewHerramientas.DataSource = herramienta.conexionConLaTabla();
        }

        private void dataGridViewHerramientas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = herramienta.conexionConLaTabla();
                txbIDHerramienta.Text = dt.Rows[e.RowIndex][0].ToString();
                txbMarcaHerramienta.Text = dt.Rows[e.RowIndex][1].ToString();
                txbTipoHerramienta.Text = dt.Rows[e.RowIndex][2].ToString();
                txbCodigoHerramienta.Text = dt.Rows[e.RowIndex][3].ToString();
                txbIDHerramienta.Enabled = false;
                btnAnyadirHerramienta.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnAnyadirHerramienta_Click(object sender, EventArgs e)
        {
            herramienta.marca = txbMarcaHerramienta.Text;
            herramienta.tipo = txbTipoHerramienta.Text;
            herramienta.codigo = txbCodigoHerramienta.Text;
            herramienta.agregarHerramienta(herramienta);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnModificarHerramienta_Click(object sender, EventArgs e)
        {
            herramienta.id_herramienta = txbIDHerramienta.Text;
            herramienta.marca = txbMarcaHerramienta.Text;
            herramienta.tipo = txbTipoHerramienta.Text;
            herramienta.codigo = txbCodigoHerramienta.Text;
            herramienta.modificarHerramienta(herramienta);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnEliminarHerramienta_Click(object sender, EventArgs e)
        {
            herramienta.id_herramienta = txbIDHerramienta.Text;
            herramienta.eliminarHerramienta(herramienta);
            refrescarTabla();
            limpiarPantalla();
        }

        private void refrescarTabla()
        {
            dataGridViewHerramientas.DataSource = herramienta.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            btnAnyadirHerramienta.Enabled = true;
            txbIDHerramienta.Text = "";
            txbMarcaHerramienta.Text = "";
            txbTipoHerramienta.Text = "";
            txbCodigoHerramienta.Text = "";
        }
    }
}
