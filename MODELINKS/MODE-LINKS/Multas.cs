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
    public partial class Multas : Form
    {
        Multa multa = new Multa();

        //PARA MARCAS DE AGUA DE LOS TEXTBOX
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);
        public Multas()
        {
            InitializeComponent(); 

            //MARCAS DE AGUA DE LOS TEXTBOX
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbIDMulta.Handle, EM_SETCUEBANNER, 10, " ID Multa");
            SendMessage(txbDia.Handle, EM_SETCUEBANNER, 10, " Dia");
            SendMessage(txbHora.Handle, EM_SETCUEBANNER, 10, " Hora");
            SendMessage(txbCantidad.Handle, EM_SETCUEBANNER, 10, " Cantidad");
            SendMessage(txbCodigoMulta.Handle, EM_SETCUEBANNER, 10, " Codigo Multa");
            SendMessage(txbMatricula.Handle, EM_SETCUEBANNER, 10, " Matricula");
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

        private void Multas_Load(object sender, EventArgs e)
        {
            dataGridViewMultas.DataSource = multa.conexionConLaTabla();
        }

        private void dataGridViewMultas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataTable dt = multa.conexionConLaTabla();
                txbIDMulta.Text = dt.Rows[e.RowIndex][0].ToString();
                txbCodigoMulta.Text = dt.Rows[e.RowIndex][1].ToString();
                txbDia.Text = dt.Rows[e.RowIndex][2].ToString();
                txbHora.Text = dt.Rows[e.RowIndex][3].ToString();
                txbCantidad.Text = dt.Rows[e.RowIndex][4].ToString();              
                txbMatricula.Text = dt.Rows[e.RowIndex][5].ToString();
                txbIDMulta.Enabled = false;
                btnAnyadirMulta.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                limpiarPantalla();
            }
        }

        private void btnAnyadirMulta_Click(object sender, EventArgs e)
        {
            multa.codigo = txbCodigoMulta.Text;
            multa.dia = txbDia.Text;
            multa.hora = txbHora.Text;
            multa.cantidad = txbCantidad.Text;
            multa.matricula = txbMatricula.Text;
            multa.agregarMulta(multa);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnModificarMulta_Click(object sender, EventArgs e)
        {
            multa.id_multa = txbIDMulta.Text;
            multa.codigo = txbCodigoMulta.Text;
            multa.dia = txbDia.Text;
            multa.hora = txbHora.Text;
            multa.cantidad = txbCantidad.Text;
            multa.matricula = txbMatricula.Text;
            multa.modificarMulta(multa);
            refrescarTabla();
            limpiarPantalla();
        }

        private void btnEliminarMulta_Click(object sender, EventArgs e)
        {
            multa.id_multa = txbIDMulta.Text;
            multa.eliminarMulta(multa);
            refrescarTabla();
            limpiarPantalla();
        }

        private void refrescarTabla()
        {
            dataGridViewMultas.DataSource = multa.conexionConLaTabla();
        }

        private void limpiarPantalla()
        {
            btnAnyadirMulta.Enabled = true;
            txbIDMulta.Text = "";
            txbCodigoMulta.Text = "";
            txbDia.Text = "";
            txbHora.Text = "";
            txbCantidad.Text = "";
            txbMatricula.Text = "";
        }
    }
}
