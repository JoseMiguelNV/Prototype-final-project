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
    public partial class Proyectos : Form
    {
        Proyecto proyecto = new Proyecto();

        //PARA MARCAS DE AGUA DE LOS TEXTBOX
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
        public Proyectos()                                                                                             
        {                             
            InitializeComponent();    
            
            //MARCAS DE AGUA DE LOS TEXTBOX
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbIDProyecto.Handle, EM_SETCUEBANNER, 10, " ID Proyecto");
            SendMessage(txbContrata.Handle, EM_SETCUEBANNER, 10, " Contrata");
            SendMessage(txbDescripcion.Handle, EM_SETCUEBANNER, 10, " Descripcion del Proyecto");
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

        private void Proyectos_Load(object sender, EventArgs e)
        {
            dataGridViewProyectos.DataSource = proyecto.conexionConLaTabla();
        }

        private void dataGridViewProyectos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = proyecto.conexionConLaTabla();
                txbIDProyecto.Text = dt.Rows[e.RowIndex][0].ToString();
                txbContrata.Text = dt.Rows[e.RowIndex][1].ToString();
                txbDescripcion.Text = dt.Rows[e.RowIndex][2].ToString();
                txbIDProyecto.Enabled = false;
                btnAnyadirProyecto.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnAnyadirProyecto_Click(object sender, EventArgs e)
        {
            proyecto.contrata = txbContrata.Text;
            proyecto.descripcion = txbDescripcion.Text;
            proyecto.agregarProyecto(proyecto);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnModificarProyecto_Click(object sender, EventArgs e)
        {
            proyecto.id_proyecto = txbIDProyecto.Text;
            proyecto.contrata = txbContrata.Text;
            proyecto.descripcion = txbDescripcion.Text;
            proyecto.modificarProyecto(proyecto);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnEliminarProyecto_Click(object sender, EventArgs e)
        {
            proyecto.id_proyecto = txbIDProyecto.Text;
            proyecto.eliminarProyecto(proyecto);
            refrescarTabla();
            limpiarPantalla();
        }

        private void refrescarTabla()
        {
            dataGridViewProyectos.DataSource = proyecto.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            btnAnyadirProyecto.Enabled = true;
            txbIDProyecto.Text = "";
            txbContrata.Text = "";
            txbDescripcion.Text = "";
        }
    }
}
