using System.Windows.Forms;

namespace Ahorcadito
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPalabra;
        private System.Windows.Forms.Label lblIntentos;
        private System.Windows.Forms.Label lblTiempo;
        private Button btnJugarDeNuevo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lblPalabra = new System.Windows.Forms.Label();
            this.lblIntentos = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.btnJugarDeNuevo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPalabra
            // 
            this.lblPalabra.BackColor = System.Drawing.Color.Transparent;
            this.lblPalabra.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalabra.Location = new System.Drawing.Point(177, 391);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(384, 68);
            this.lblPalabra.TabIndex = 4;
            this.lblPalabra.Text = "f";
            // 
            // lblIntentos
            // 
            this.lblIntentos.BackColor = System.Drawing.Color.Transparent;
            this.lblIntentos.Font = new System.Drawing.Font("Comic Sans MS", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblIntentos.Location = new System.Drawing.Point(468, 38);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new System.Drawing.Size(192, 55);
            this.lblIntentos.TabIndex = 4;
            this.lblIntentos.Text = "d";
            // 
            // lblTiempo
            // 
            this.lblTiempo.BackColor = System.Drawing.Color.Transparent;
            this.lblTiempo.Font = new System.Drawing.Font("Comic Sans MS", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTiempo.Location = new System.Drawing.Point(468, 78);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(197, 62);
            this.lblTiempo.TabIndex = 4;
            // 
            // btnJugarDeNuevo
            // 
            this.btnJugarDeNuevo.BackColor = System.Drawing.Color.Orange;
            this.btnJugarDeNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJugarDeNuevo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugarDeNuevo.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnJugarDeNuevo.Location = new System.Drawing.Point(478, 600);
            this.btnJugarDeNuevo.Name = "btnJugarDeNuevo";
            this.btnJugarDeNuevo.Size = new System.Drawing.Size(157, 47);
            this.btnJugarDeNuevo.TabIndex = 3;
            this.btnJugarDeNuevo.Text = "Jugar de Nuevo";
            this.btnJugarDeNuevo.UseVisualStyleBackColor = false;
            this.btnJugarDeNuevo.Visible = false;
            this.btnJugarDeNuevo.Click += new System.EventHandler(this.btnJugarDeNuevo_Click);
            // 
            // Form3
            // 
            this.BackgroundImage = global::Ahorcadito.Properties.Resources.Untitled_design;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(672, 670);
            this.Controls.Add(this.btnJugarDeNuevo);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblIntentos);
            this.Controls.Add(this.lblPalabra);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ahorcado";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
    }
}