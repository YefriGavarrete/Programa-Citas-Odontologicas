namespace Sistema.FormLoginMenu
{
    partial class InicioLOGO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioLOGO));
            this.LogoInicio = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoInicio)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoInicio
            // 
            this.LogoInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoInicio.Image = ((System.Drawing.Image)(resources.GetObject("LogoInicio.Image")));
            this.LogoInicio.Location = new System.Drawing.Point(0, 0);
            this.LogoInicio.Name = "LogoInicio";
            this.LogoInicio.Size = new System.Drawing.Size(800, 450);
            this.LogoInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoInicio.TabIndex = 8;
            this.LogoInicio.TabStop = false;
            // 
            // InicioLOGO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogoInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InicioLOGO";
            this.Text = "InicioLOGO";
            ((System.ComponentModel.ISupportInitialize)(this.LogoInicio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoInicio;
    }
}