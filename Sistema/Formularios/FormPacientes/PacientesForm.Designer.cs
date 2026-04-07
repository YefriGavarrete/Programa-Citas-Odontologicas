namespace Sistema.Formularios.FormPacientes
{
    partial class PacientesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacientesForm));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dgvCitasDia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.lblSinCitas = new System.Windows.Forms.Label();
            this.btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCalendario = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminar = new Guna.UI2.WinForms.Guna2Button();
            this.btnRegresar = new Guna.UI2.WinForms.Guna2Button();
            this.pnlGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasDia)).BeginInit();
            this.pnlCalendario.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monthCalendar1.Location = new System.Drawing.Point(7, 8);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(7);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dgvCitasDia
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.dgvCitasDia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitasDia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvCitasDia.ColumnHeadersHeight = 32;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCitasDia.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvCitasDia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCitasDia.Location = new System.Drawing.Point(14, 32);
            this.dgvCitasDia.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCitasDia.Name = "dgvCitasDia";
            this.dgvCitasDia.ReadOnly = true;
            this.dgvCitasDia.RowHeadersVisible = false;
            this.dgvCitasDia.RowHeadersWidth = 51;
            this.dgvCitasDia.RowTemplate.Height = 28;
            this.dgvCitasDia.Size = new System.Drawing.Size(501, 370);
            this.dgvCitasDia.TabIndex = 5;
            this.dgvCitasDia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCitasDia.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCitasDia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCitasDia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCitasDia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCitasDia.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCitasDia.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCitasDia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCitasDia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCitasDia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCitasDia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCitasDia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCitasDia.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvCitasDia.ThemeStyle.ReadOnly = true;
            this.dgvCitasDia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCitasDia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCitasDia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCitasDia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCitasDia.ThemeStyle.RowsStyle.Height = 28;
            this.dgvCitasDia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCitasDia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblFechaActual.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaActual.Location = new System.Drawing.Point(8, 8);
            this.lblFechaActual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(99, 18);
            this.lblFechaActual.TabIndex = 3;
            this.lblFechaActual.Text = "Citas del día:";
            // 
            // lblSinCitas
            // 
            this.lblSinCitas.AutoSize = true;
            this.lblSinCitas.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.lblSinCitas.ForeColor = System.Drawing.Color.Gray;
            this.lblSinCitas.Location = new System.Drawing.Point(15, 36);
            this.lblSinCitas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinCitas.Name = "lblSinCitas";
            this.lblSinCitas.Size = new System.Drawing.Size(192, 16);
            this.lblSinCitas.TabIndex = 4;
            this.lblSinCitas.Text = "No hay citas para esta fecha.";
            this.lblSinCitas.Visible = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCerrar.BorderRadius = 8;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FillColor = System.Drawing.Color.LightCoral;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.HoverState.FillColor = System.Drawing.Color.Crimson;
            this.btnCerrar.Location = new System.Drawing.Point(759, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(68, 24);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "✕  Cerrar";
            this.btnCerrar.Visible = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlCalendario
            // 
            this.pnlCalendario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlCalendario.BackColor = System.Drawing.Color.Transparent;
            this.pnlCalendario.BorderRadius = 10;
            this.pnlCalendario.BorderThickness = 2;
            this.pnlCalendario.Controls.Add(this.guna2Panel1);
            this.pnlCalendario.Controls.Add(this.pictureBox1);
            this.pnlCalendario.Controls.Add(this.label1);
            this.pnlCalendario.Controls.Add(this.btnEliminar);
            this.pnlCalendario.Controls.Add(this.btnRegresar);
            this.pnlCalendario.FillColor = System.Drawing.Color.White;
            this.pnlCalendario.Location = new System.Drawing.Point(12, 34);
            this.pnlCalendario.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCalendario.Name = "pnlCalendario";
            this.pnlCalendario.Size = new System.Drawing.Size(287, 416);
            this.pnlCalendario.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.monthCalendar1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2Panel1.Location = new System.Drawing.Point(13, 9);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(261, 179);
            this.guna2Panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(62, 265);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 107;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(46, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 11);
            this.label1.TabIndex = 6;
            this.label1.Text = "Presione un registro para Eliminar Cita";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BorderRadius = 8;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FillColor = System.Drawing.Color.Crimson;
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.Location = new System.Drawing.Point(46, 218);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(196, 36);
            this.btnEliminar.TabIndex = 106;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BorderRadius = 8;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnRegresar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnRegresar.Location = new System.Drawing.Point(217, 387);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(103, 36);
            this.btnRegresar.TabIndex = 105;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.Visible = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.BorderRadius = 10;
            this.pnlGrid.BorderThickness = 2;
            this.pnlGrid.Controls.Add(this.lblFechaActual);
            this.pnlGrid.Controls.Add(this.lblSinCitas);
            this.pnlGrid.Controls.Add(this.dgvCitasDia);
            this.pnlGrid.FillColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(312, 34);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(528, 416);
            this.pnlGrid.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 24);
            this.panel1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(2, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Citas Programadas    -    Seleccione una fecha en el calendario";
            // 
            // PacientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(853, 468);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pnlCalendario);
            this.Controls.Add(this.pnlGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PacientesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Citas Programadas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasDia)).EndInit();
            this.pnlCalendario.ResumeLayout(false);
            this.pnlCalendario.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCitasDia;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.Label lblSinCitas;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Guna.UI2.WinForms.Guna2Panel pnlCalendario;
        private Guna.UI2.WinForms.Guna2Panel pnlGrid;
        private Guna.UI2.WinForms.Guna2Button btnRegresar;

        private Guna.UI2.WinForms.Guna2Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}
