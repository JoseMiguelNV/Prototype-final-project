using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MODE_LINKS
{
    public partial class InicioSesion : Form
    {
        SqlConnection conexion = new SqlConnection(@"Data Source = LAPTOP-22N1MPUV\SQLEXPRESS; Initial Catalog = BD_MODELINKS;Integrated Security = True");

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);

        public InicioSesion()
        {
            InitializeComponent();
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
            imgAdvertencia.Visible = false;
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

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            pbxMostrarContraseña.BringToFront();
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            Regex validacionDNI = new Regex("^[0-9]{8}[A-Z]{1}$");
            if (txbUsuario.Text == "" || txbContrasenya.Text == "")
            {
                imgAdvertencia.Visible = true;
                lblMensaje.Text = "Debe introducir usuario y contraseña.";
            }
            else if (validacionDNI.IsMatch(txbUsuario.Text))
            {
                logear(txbUsuario.Text, txbContrasenya.Text);
            }
            else
            {
                imgAdvertencia.Visible = true;
                lblMensaje.Text = "Usuario y/o contraseña incorrecta.";
            }
        }

        private void logear(string dni, string contrasenya)
        {
            string cadenaSql = @"select dni, contrasenya, tipo_usuario, nombre, apellido1, apellido2, imagen
                                   from TECNICOS
                                  where @usuario = dni
                                    and @contrasenya = contrasenya;";
            try
            {
                conexion.Open();
                SqlCommand comand = new SqlCommand(cadenaSql, conexion);
                comand.Parameters.AddWithValue("@usuario", dni);
                comand.Parameters.AddWithValue("@contrasenya", contrasenya);
                SqlDataAdapter adapter = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][2].ToString() == "Administrador")
                    {
                        Principal principal = new Principal();
                        this.Hide();
                        principal.usuario = dt.Rows[0][2].ToString();
                        principal.nombre = dt.Rows[0][3].ToString();
                        principal.apellido1 = dt.Rows[0][4].ToString();
                        principal.apellido2 = dt.Rows[0][5].ToString();
                        principal.imagen = dt.Rows[0][6].ToString();
                        principal.ShowDialog();
                    }
                    else 
                    {
                        MessageBox.Show("No tienes permisos de administrador.");
                    }
                }
                else
                {
                    imgAdvertencia.Visible = true;
                    lblMensaje.Text = "Usuario y/o contraseña incorrecta.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexion.Close();
            }
            finally
            {
                conexion.Close();
            }
        }

        private void pbxMostrarContraseña_Click(object sender, EventArgs e)
        {
            pbxOcultarContrasenya.BringToFront();
            txbContrasenya.UseSystemPasswordChar = false;
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
        }

        private void pbxOcultarContrasenya_Click(object sender, EventArgs e)
        {
            pbxMostrarContraseña.BringToFront();
            txbContrasenya.UseSystemPasswordChar = true;
            SendMessage(txbUsuario.Handle, EM_SETCUEBANNER, 10, " Usuario");
            SendMessage(txbContrasenya.Handle, EM_SETCUEBANNER, 10, " Contraseña");
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkOlvidarContrasenya_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CambioContraseña cambioContrasenya = new CambioContraseña();
            try
            {
                cambioContrasenya.usuario = txbUsuario.Text;
                cambioContrasenya.ShowDialog();
            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InicioSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txbUsuario_Click(object sender, EventArgs e)
        {
            imgAdvertencia.Visible = false;
            lblMensaje.Text = "";
        }

        private void txbContrasenya_Click(object sender, EventArgs e)
        {
            imgAdvertencia.Visible = false;
            lblMensaje.Text = "";
        }
    }
}
