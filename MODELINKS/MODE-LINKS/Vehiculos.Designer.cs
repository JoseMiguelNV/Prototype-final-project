namespace MODE_LINKS
{
    partial class Vehiculos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelVehiculos = new System.Windows.Forms.Panel();
            this.groupBoxListaVehiculos = new System.Windows.Forms.GroupBox();
            this.dataGridViewVehiculos = new System.Windows.Forms.DataGridView();
            this.groupBoxTecnicos = new System.Windows.Forms.GroupBox();
            this.panel1Vehiculos = new System.Windows.Forms.Panel();
            this.txbIDMulta = new System.Windows.Forms.TextBox();
            this.txbSalida = new System.Windows.Forms.TextBox();
            this.txbMatricula = new System.Windows.Forms.TextBox();
            this.txbMarca = new System.Windows.Forms.TextBox();
            this.txbModelo = new System.Windows.Forms.TextBox();
            this.txbEntrada = new System.Windows.Forms.TextBox();
            this.btnAnyadirVehículo = new System.Windows.Forms.Button();
            this.txbIDVehiculo = new System.Windows.Forms.TextBox();
            this.btnModificarVehículo = new System.Windows.Forms.Button();
            this.btnEliminarTecnico = new System.Windows.Forms.Button();
            this.panelVehiculos.SuspendLayout();
            this.groupBoxListaVehiculos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehiculos)).BeginInit();
            this.groupBoxTecnicos.SuspendLayout();
            this.panel1Vehiculos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelVehiculos
            // 
            this.panelVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVehiculos.Controls.Add(this.groupBoxListaVehiculos);
            this.panelVehiculos.Controls.Add(this.groupBoxTecnicos);
            this.panelVehiculos.Location = new System.Drawing.Point(0, -1);
            this.panelVehiculos.Name = "panelVehiculos";
            this.panelVehiculos.Size = new System.Drawing.Size(930, 517);
            this.panelVehiculos.TabIndex = 1;
            // 
            // groupBoxListaVehiculos
            // 
            this.groupBoxListaVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxListaVehiculos.Controls.Add(this.dataGridViewVehiculos);
            this.groupBoxListaVehiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxListaVehiculos.ForeColor = System.Drawing.Color.Aquamarine;
            this.groupBoxListaVehiculos.Location = new System.Drawing.Point(12, 296);
            this.groupBoxListaVehiculos.Name = "groupBoxListaVehiculos";
            this.groupBoxListaVehiculos.Size = new System.Drawing.Size(906, 207);
            this.groupBoxListaVehiculos.TabIndex = 33;
            this.groupBoxListaVehiculos.TabStop = false;
            this.groupBoxListaVehiculos.Text = "Lista de Vehículos";
            // 
            // dataGridViewVehiculos
            // 
            this.dataGridViewVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewVehiculos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewVehiculos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.dataGridViewVehiculos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewVehiculos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVehiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewVehiculos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewVehiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVehiculos.EnableHeadersVisualStyles = false;
            this.dataGridViewVehiculos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.dataGridViewVehiculos.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewVehiculos.Name = "dataGridViewVehiculos";
            this.dataGridViewVehiculos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVehiculos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewVehiculos.RowHeadersWidth = 20;
            this.dataGridViewVehiculos.Size = new System.Drawing.Size(900, 182);
            this.dataGridViewVehiculos.TabIndex = 42;
            this.dataGridViewVehiculos.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewVehiculos_RowHeaderMouseClick);
            // 
            // groupBoxTecnicos
            // 
            this.groupBoxTecnicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTecnicos.Controls.Add(this.panel1Vehiculos);
            this.groupBoxTecnicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTecnicos.ForeColor = System.Drawing.Color.Aquamarine;
            this.groupBoxTecnicos.Location = new System.Drawing.Point(12, 3);
            this.groupBoxTecnicos.Name = "groupBoxTecnicos";
            this.groupBoxTecnicos.Size = new System.Drawing.Size(906, 290);
            this.groupBoxTecnicos.TabIndex = 32;
            this.groupBoxTecnicos.TabStop = false;
            this.groupBoxTecnicos.Text = "Gestión de Técnicos";
            // 
            // panel1Vehiculos
            // 
            this.panel1Vehiculos.Controls.Add(this.txbIDMulta);
            this.panel1Vehiculos.Controls.Add(this.txbSalida);
            this.panel1Vehiculos.Controls.Add(this.txbMatricula);
            this.panel1Vehiculos.Controls.Add(this.txbMarca);
            this.panel1Vehiculos.Controls.Add(this.txbModelo);
            this.panel1Vehiculos.Controls.Add(this.txbEntrada);
            this.panel1Vehiculos.Controls.Add(this.btnAnyadirVehículo);
            this.panel1Vehiculos.Controls.Add(this.txbIDVehiculo);
            this.panel1Vehiculos.Controls.Add(this.btnModificarVehículo);
            this.panel1Vehiculos.Controls.Add(this.btnEliminarTecnico);
            this.panel1Vehiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1Vehiculos.Location = new System.Drawing.Point(3, 22);
            this.panel1Vehiculos.Name = "panel1Vehiculos";
            this.panel1Vehiculos.Size = new System.Drawing.Size(900, 265);
            this.panel1Vehiculos.TabIndex = 0;
            // 
            // txbIDMulta
            // 
            this.txbIDMulta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbIDMulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbIDMulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIDMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIDMulta.ForeColor = System.Drawing.Color.White;
            this.txbIDMulta.Location = new System.Drawing.Point(367, 166);
            this.txbIDMulta.Name = "txbIDMulta";
            this.txbIDMulta.Size = new System.Drawing.Size(238, 21);
            this.txbIDMulta.TabIndex = 7;
            this.txbIDMulta.Tag = "";
            // 
            // txbSalida
            // 
            this.txbSalida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSalida.ForeColor = System.Drawing.Color.White;
            this.txbSalida.Location = new System.Drawing.Point(367, 120);
            this.txbSalida.Name = "txbSalida";
            this.txbSalida.Size = new System.Drawing.Size(238, 21);
            this.txbSalida.TabIndex = 6;
            this.txbSalida.Tag = "";
            // 
            // txbMatricula
            // 
            this.txbMatricula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMatricula.ForeColor = System.Drawing.Color.White;
            this.txbMatricula.Location = new System.Drawing.Point(93, 98);
            this.txbMatricula.Name = "txbMatricula";
            this.txbMatricula.Size = new System.Drawing.Size(237, 21);
            this.txbMatricula.TabIndex = 2;
            this.txbMatricula.Tag = "";
            // 
            // txbMarca
            // 
            this.txbMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMarca.ForeColor = System.Drawing.Color.White;
            this.txbMarca.Location = new System.Drawing.Point(93, 146);
            this.txbMarca.Name = "txbMarca";
            this.txbMarca.Size = new System.Drawing.Size(237, 21);
            this.txbMarca.TabIndex = 3;
            this.txbMarca.Tag = "";
            // 
            // txbModelo
            // 
            this.txbModelo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelo.ForeColor = System.Drawing.Color.White;
            this.txbModelo.Location = new System.Drawing.Point(93, 192);
            this.txbModelo.Name = "txbModelo";
            this.txbModelo.Size = new System.Drawing.Size(237, 21);
            this.txbModelo.TabIndex = 4;
            this.txbModelo.Tag = "";
            // 
            // txbEntrada
            // 
            this.txbEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbEntrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEntrada.ForeColor = System.Drawing.Color.White;
            this.txbEntrada.Location = new System.Drawing.Point(367, 76);
            this.txbEntrada.Name = "txbEntrada";
            this.txbEntrada.Size = new System.Drawing.Size(238, 21);
            this.txbEntrada.TabIndex = 5;
            this.txbEntrada.Tag = "";
            // 
            // btnAnyadirVehículo
            // 
            this.btnAnyadirVehículo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAnyadirVehículo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.btnAnyadirVehículo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnyadirVehículo.ForeColor = System.Drawing.Color.Aquamarine;
            this.btnAnyadirVehículo.Location = new System.Drawing.Point(683, 62);
            this.btnAnyadirVehículo.MaximumSize = new System.Drawing.Size(245, 35);
            this.btnAnyadirVehículo.MinimumSize = new System.Drawing.Size(145, 35);
            this.btnAnyadirVehículo.Name = "btnAnyadirVehículo";
            this.btnAnyadirVehículo.Size = new System.Drawing.Size(145, 35);
            this.btnAnyadirVehículo.TabIndex = 38;
            this.btnAnyadirVehículo.Text = "Añadir vehículo";
            this.btnAnyadirVehículo.UseVisualStyleBackColor = false;
            this.btnAnyadirVehículo.Click += new System.EventHandler(this.btnAnyadirVehículo_Click);
            // 
            // txbIDVehiculo
            // 
            this.txbIDVehiculo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbIDVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbIDVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIDVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIDVehiculo.ForeColor = System.Drawing.Color.White;
            this.txbIDVehiculo.Location = new System.Drawing.Point(93, 49);
            this.txbIDVehiculo.Name = "txbIDVehiculo";
            this.txbIDVehiculo.Size = new System.Drawing.Size(237, 21);
            this.txbIDVehiculo.TabIndex = 1;
            this.txbIDVehiculo.Tag = "";
            // 
            // btnModificarVehículo
            // 
            this.btnModificarVehículo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificarVehículo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.btnModificarVehículo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarVehículo.ForeColor = System.Drawing.Color.Aquamarine;
            this.btnModificarVehículo.Location = new System.Drawing.Point(683, 112);
            this.btnModificarVehículo.MaximumSize = new System.Drawing.Size(245, 35);
            this.btnModificarVehículo.MinimumSize = new System.Drawing.Size(145, 35);
            this.btnModificarVehículo.Name = "btnModificarVehículo";
            this.btnModificarVehículo.Size = new System.Drawing.Size(145, 35);
            this.btnModificarVehículo.TabIndex = 39;
            this.btnModificarVehículo.Text = "Modificar vehículo";
            this.btnModificarVehículo.UseVisualStyleBackColor = false;
            this.btnModificarVehículo.Click += new System.EventHandler(this.btnModificarVehículo_Click);
            // 
            // btnEliminarTecnico
            // 
            this.btnEliminarTecnico.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnEliminarTecnico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.btnEliminarTecnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTecnico.ForeColor = System.Drawing.Color.Aquamarine;
            this.btnEliminarTecnico.Location = new System.Drawing.Point(683, 167);
            this.btnEliminarTecnico.MaximumSize = new System.Drawing.Size(245, 35);
            this.btnEliminarTecnico.MinimumSize = new System.Drawing.Size(145, 35);
            this.btnEliminarTecnico.Name = "btnEliminarTecnico";
            this.btnEliminarTecnico.Size = new System.Drawing.Size(145, 35);
            this.btnEliminarTecnico.TabIndex = 40;
            this.btnEliminarTecnico.Text = "Eliminar vehículo";
            this.btnEliminarTecnico.UseVisualStyleBackColor = false;
            this.btnEliminarTecnico.Click += new System.EventHandler(this.btnEliminarTecnico_Click);
            // 
            // Vehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(930, 516);
            this.Controls.Add(this.panelVehiculos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Vehiculos";
            this.Text = "Vehiculos";
            this.Load += new System.EventHandler(this.Vehiculos_Load);
            this.panelVehiculos.ResumeLayout(false);
            this.groupBoxListaVehiculos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehiculos)).EndInit();
            this.groupBoxTecnicos.ResumeLayout(false);
            this.panel1Vehiculos.ResumeLayout(false);
            this.panel1Vehiculos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelVehiculos;
        private System.Windows.Forms.GroupBox groupBoxListaVehiculos;
        private System.Windows.Forms.GroupBox groupBoxTecnicos;
        private System.Windows.Forms.Panel panel1Vehiculos;
        private System.Windows.Forms.TextBox txbIDMulta;
        private System.Windows.Forms.TextBox txbSalida;
        private System.Windows.Forms.TextBox txbMatricula;
        private System.Windows.Forms.TextBox txbMarca;
        private System.Windows.Forms.TextBox txbModelo;
        private System.Windows.Forms.TextBox txbEntrada;
        private System.Windows.Forms.Button btnAnyadirVehículo;
        private System.Windows.Forms.TextBox txbIDVehiculo;
        private System.Windows.Forms.Button btnModificarVehículo;
        private System.Windows.Forms.Button btnEliminarTecnico;
        private System.Windows.Forms.DataGridView dataGridViewVehiculos;
    }
}