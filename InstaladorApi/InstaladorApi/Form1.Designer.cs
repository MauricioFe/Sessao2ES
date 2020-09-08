namespace InstaladorApi
{
    partial class FrmApi
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnParar = new System.Windows.Forms.Button();
            this.lblStaus = new System.Windows.Forms.Label();
            this.lblFirewall = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(296, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "label";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIniciar
            // 
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Location = new System.Drawing.Point(261, 253);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(166, 36);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar Serviço";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnParar
            // 
            this.btnParar.FlatAppearance.BorderSize = 0;
            this.btnParar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParar.Location = new System.Drawing.Point(503, 253);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(166, 36);
            this.btnParar.TabIndex = 3;
            this.btnParar.Text = "Parar Serviço";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // lblStaus
            // 
            this.lblStaus.AutoSize = true;
            this.lblStaus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.lblStaus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaus.ForeColor = System.Drawing.Color.White;
            this.lblStaus.Location = new System.Drawing.Point(397, 367);
            this.lblStaus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStaus.Name = "lblStaus";
            this.lblStaus.Size = new System.Drawing.Size(115, 37);
            this.lblStaus.TabIndex = 4;
            this.lblStaus.Text = "Status";
            this.lblStaus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStaus.Visible = false;
            // 
            // lblFirewall
            // 
            this.lblFirewall.AutoSize = true;
            this.lblFirewall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.lblFirewall.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirewall.ForeColor = System.Drawing.Color.White;
            this.lblFirewall.Location = new System.Drawing.Point(296, 439);
            this.lblFirewall.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFirewall.Name = "lblFirewall";
            this.lblFirewall.Size = new System.Drawing.Size(357, 37);
            this.lblFirewall.TabIndex = 5;
            this.lblFirewall.Text = "Porta 5005 bloqueada";
            this.lblFirewall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFirewall.Visible = false;
            // 
            // FrmApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InstaladorApi.Properties.Resources.modelo_formulario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(903, 558);
            this.Controls.Add(this.lblFirewall);
            this.Controls.Add(this.lblStaus);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "API sessão 2";
            this.Load += new System.EventHandler(this.FrmApi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.Label lblStaus;
        private System.Windows.Forms.Label lblFirewall;
    }
}

