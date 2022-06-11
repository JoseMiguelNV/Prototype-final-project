using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODE_LINKS
{
    public partial class CambioContraseña : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS; Integrated Security = True");
        public string usuario { get; set; }


        //PARA MARCAS DE AGUA DE LOS TEXTBOX
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        public CambioContraseña()
        {
            InitializeComponent();
         
            //MARCAS DE AGUA DE LOS TEXTBOX
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Nueva Contraseña");
            SendMessage(txbNuevaContrasenya.Handle, EM_SETCUEBANNER, 10, " Repetir contraseña");
            imgAdvertencia.Visible = false;
        }

        private void CambioContraseña_Load(object sender, EventArgs e)
        {
            txbUsuario.Text = usuario.ToString();
            pbxMostrarContrasenya.BringToFront();
            pxbMostrarContrasenya1.BringToFront();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCambioContrasenya_Click(object sender, EventArgs e)
        {
            if (txbContrasenya.Text == "" || txbNuevaContrasenya.Text == "")
            {
                imgAdvertencia.Visible = true;
                lblMensaje.Text = "Debe introducir dos veces la misma contraseña.";
            }
            else if (txbContrasenya.Text.Equals(txbNuevaContrasenya.Text))
            {
                guardarContrasenya(txbUsuario.Text, txbNuevaContrasenya.Text);  
            }
            else
            {
                imgAdvertencia.Visible = true;
                lblMensaje.Text = "Las contraseñas no coinciden.";
            }
        }

        private void guardarContrasenya(string usuario, string nuevaContrasenya)
        {
            string cadenaSql = @"UPDATE tecnicos 
                                    SET contrasenya = @contrasenya 
                                  WHERE dni = @dni";
            try
            {
                conexion.Open();
                SqlCommand comand = new SqlCommand(cadenaSql, conexion);
                comand.Parameters.AddWithValue("@contrasenya", nuevaContrasenya);
                comand.Parameters.AddWithValue("@dni", usuario);
                comand.ExecuteNonQuery();
                MessageBox.Show("Contraseña actualizada correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void txbContrasenya_Click(object sender, EventArgs e)
        {
            imgAdvertencia.Visible = false;
            lblMensaje.Text = "";
        }

        private void txbNuevaContrasenya_Click(object sender, EventArgs e)
        {
            imgAdvertencia.Visible = false;
            lblMensaje.Text = "";
        }

        private void pxbMostrarContrasenya1_Click(object sender, EventArgs e)
        {
            pxbOcultarContrasenya1.BringToFront();
            txbContrasenya.UseSystemPasswordChar = false;
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            SendMessage(txbNuevaContrasenya.Handle, EM_SETCUEBANNER, 10, " Nueva Contraseña");
        }

        private void pxbOcultarContrasenya1_Click(object sender, EventArgs e)
        {
            pxbMostrarContrasenya1.BringToFront();
            txbContrasenya.UseSystemPasswordChar = true;
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            SendMessage(txbNuevaContrasenya.Handle, EM_SETCUEBANNER, 10, " Nueva Contraseña");
        }

        private void pbxMostrarContrasenya_Click(object sender, EventArgs e)
        {
            pbxOcultarContrasenya.BringToFront();
            txbNuevaContrasenya.UseSystemPasswordChar = false;
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            SendMessage(txbNuevaContrasenya.Handle, EM_SETCUEBANNER, 10, " Nueva Contraseña");
        }

        private void pbxOcultarContrasenya_Click(object sender, EventArgs e)
        {
            pbxMostrarContrasenya.BringToFront();
            txbNuevaContrasenya.UseSystemPasswordChar = true;
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            SendMessage(txbNuevaContrasenya.Handle, EM_SETCUEBANNER, 10, " Nueva Contraseña");
        }

    }
}
