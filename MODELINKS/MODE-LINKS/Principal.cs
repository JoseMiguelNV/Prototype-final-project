using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace MODE_LINKS
{
    public partial class Principal : Form
    {
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string usuario { get; set; }
        public string imagen { get; set; }

      

        //ATRIBUTOS PARA REDIMENSIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION
        //FUENTE, STACK OVERFLOW
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        internal static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute, ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute, uint cbAttribute);

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

        public Principal()
        {
            InitializeComponent();
            var attribute = DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            DwmSetWindowAttribute(this.Handle, attribute, ref preference, sizeof(uint));
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }
           
        private void Principal_Load(object sender, EventArgs e)
        {
            MostrarFormLogo();
            pictureBoxUsuario.Enabled = true;
            lblAdministrador.Text = usuario.ToString();
            lblNombre.Text = nombre.ToString();
            lblApellidos.Text = apellido1.ToString() + " " + apellido2.ToString();           
            if (imagen == "")
            {
                pictureBoxUsuario.Image = new Bitmap(@"C:\Users\josem\OneDrive\Escritorio\FCT\MODE-LINKS\MODE-LINKS\Resources\usuario (3).png");
            }
            else
            {
                pictureBoxUsuario.ResetText();
                pictureBoxUsuario.Image = Image.FromFile(imagen);
            }
        }

        //CAMBIA LA IMAGEN DESDE EL APARTADO DE MODIFICACION DE CUENTAS
        public void cambiarImagen(string imagen)
        {
            pictureBoxUsuario.ResetText();
            pictureBoxUsuario.Image = Image.FromFile(imagen);
        }

        //ABRIR FORMULARIOS DESDE LOS DISTINTOS APARTADOS
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        //DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        //FUENTE, STACK OVERFLOW
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }

        //COLOR Y GRIP DE RECTANGULO INFERIOR
        //FUENTE, STACK OVERFLOW
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Aquamarine, sizeGripRectangle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir de la aplicación?", "MODELINKS", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState.HasFlag(FormWindowState.Maximized))
            {
                this.WindowState = FormWindowState.Normal;
                Location = new Point(600, 300);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenuLateral_Click(object sender, EventArgs e)
        {
            //CON EFECTO SLIDING
            if (panelMenu.Width == 230)
            {
                this.timerContraerMenu.Start();
            }
            else if (panelMenu.Width == 55)
            {
                this.timerExpandirMenu.Start();
            }
        }

        private void timerExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.timerExpandirMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 5;
        }

        private void timerContraerMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 55)
                this.timerContraerMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 5;
        }

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timerHoraYFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
            lblHoras.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        //CREAR EVENTO PARA ABRIR FORMULARIOS
        //FUENTE, STACK OVERFLOW
        private void AbrirFormEnPanel(object formHijo)
        {
            if (this.panelContenedorForm.Controls.Count > 0)
            {
                this.panelContenedorForm.Controls.RemoveAt(0);
            }             
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }

        private void MostrarFormLogo()
        {
            AbrirFormEnPanel(new PanelCentralLogo());
        }

        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }

        private void btnApagado_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Cerrar sesión?", "MODELINKS", MessageBoxButtons.YesNo);
            if(dialogo == DialogResult.Yes)
            {
                Application.Restart();
            }            
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            btnCuentas.BackColor = Color.FromArgb(64, 69, 76);

            btnProyectos.BackColor = Color.FromArgb(38, 45, 53);
            btnTrabajos.BackColor = Color.FromArgb(38, 45, 53);
            btnHerramientas.BackColor = Color.FromArgb(38, 45, 53);
            btnVehiculos.BackColor = Color.FromArgb(38, 45, 53);
            btnTecnicos.BackColor = Color.FromArgb(38, 45, 53);
            btnMultas.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Cuentas());
        }

        private void btnProyectos_Click(object sender, EventArgs e)
        {
            btnProyectos.BackColor = Color.FromArgb(64, 69, 76);

            btnCuentas.BackColor = Color.FromArgb(38, 45, 53);
            btnTrabajos.BackColor = Color.FromArgb(38, 45, 53);
            btnHerramientas.BackColor = Color.FromArgb(38, 45, 53);
            btnVehiculos.BackColor = Color.FromArgb(38, 45, 53);
            btnTecnicos.BackColor = Color.FromArgb(38, 45, 53);
            btnMultas.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Proyectos());
        }

        private void btnTrabajos_Click(object sender, EventArgs e)
        {
            btnTrabajos.BackColor = Color.FromArgb(64, 69, 76);

            btnCuentas.BackColor = Color.FromArgb(38, 45, 53);
            btnProyectos.BackColor = Color.FromArgb(38, 45, 53);
            btnHerramientas.BackColor = Color.FromArgb(38, 45, 53);
            btnVehiculos.BackColor = Color.FromArgb(38, 45, 53);
            btnTecnicos.BackColor = Color.FromArgb(38, 45, 53);
            btnMultas.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Trabajos());
        
        }

        private void btnHerramientas_Click(object sender, EventArgs e)
        {
            btnHerramientas.BackColor = Color.FromArgb(64, 69, 76);

            btnCuentas.BackColor = Color.FromArgb(38, 45, 53);
            btnProyectos.BackColor = Color.FromArgb(38, 45, 53);
            btnTrabajos.BackColor = Color.FromArgb(38, 45, 53);
            btnVehiculos.BackColor = Color.FromArgb(38, 45, 53);
            btnTecnicos.BackColor = Color.FromArgb(38, 45, 53);
            btnMultas.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Herramientas());
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            btnVehiculos.BackColor = Color.FromArgb(64, 69, 76);

            btnCuentas.BackColor = Color.FromArgb(38, 45, 53);
            btnProyectos.BackColor = Color.FromArgb(38, 45, 53);
            btnTrabajos.BackColor = Color.FromArgb(38, 45, 53);
            btnHerramientas.BackColor = Color.FromArgb(38, 45, 53);
            btnTecnicos.BackColor = Color.FromArgb(38, 45, 53);
            btnMultas.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Vehiculos());
        }

        private void btnMultas_Click(object sender, EventArgs e)
        {
            btnMultas.BackColor = Color.FromArgb(64, 69, 76);

            btnCuentas.BackColor = Color.FromArgb(38, 45, 53);
            btnProyectos.BackColor = Color.FromArgb(38, 45, 53);
            btnTrabajos.BackColor = Color.FromArgb(38, 45, 53);
            btnHerramientas.BackColor = Color.FromArgb(38, 45, 53);
            btnVehiculos.BackColor = Color.FromArgb(38, 45, 53);
            btnTecnicos.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Multas());
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            btnTecnicos.BackColor = Color.FromArgb(64, 69, 76);

            btnCuentas.BackColor = Color.FromArgb(38, 45, 53);
            btnProyectos.BackColor = Color.FromArgb(38, 45, 53);
            btnTrabajos.BackColor = Color.FromArgb(38, 45, 53);
            btnHerramientas.BackColor = Color.FromArgb(38, 45, 53);
            btnVehiculos.BackColor = Color.FromArgb(38, 45, 53);
            btnMultas.BackColor = Color.FromArgb(38, 45, 53);
            AbrirFormEnPanel(new Tecnicos());
        }
    }
}
