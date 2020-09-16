namespace Sessao2.ModuloGerencial
{
    partial class FrmMenu
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
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.btnJogos3 = new System.Windows.Forms.Button();
            this.btnCampeonatos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Image = global::Sessao2.ModuloGerencial.Properties.Resources._1;
            this.btnMinimizar.Location = new System.Drawing.Point(596, 79);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(26, 26);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::Sessao2.ModuloGerencial.Properties.Resources._2;
            this.btnFechar.Location = new System.Drawing.Point(563, 47);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(26, 26);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFechar.TabIndex = 2;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnJogos3
            // 
            this.btnJogos3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnJogos3.FlatAppearance.BorderSize = 0;
            this.btnJogos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogos3.ForeColor = System.Drawing.Color.White;
            this.btnJogos3.Location = new System.Drawing.Point(273, 148);
            this.btnJogos3.Name = "btnJogos3";
            this.btnJogos3.Size = new System.Drawing.Size(226, 62);
            this.btnJogos3.TabIndex = 3;
            this.btnJogos3.Text = "Jogos ";
            this.btnJogos3.UseVisualStyleBackColor = false;
            this.btnJogos3.Click += new System.EventHandler(this.btnJogos_Click);
            // 
            // btnCampeonatos
            // 
            this.btnCampeonatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnCampeonatos.FlatAppearance.BorderSize = 0;
            this.btnCampeonatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCampeonatos.ForeColor = System.Drawing.Color.White;
            this.btnCampeonatos.Location = new System.Drawing.Point(273, 237);
            this.btnCampeonatos.Name = "btnCampeonatos";
            this.btnCampeonatos.Size = new System.Drawing.Size(226, 62);
            this.btnCampeonatos.TabIndex = 4;
            this.btnCampeonatos.Text = "Campeonatos";
            this.btnCampeonatos.UseVisualStyleBackColor = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sessao2.ModuloGerencial.Properties.Resources.modelo_formulario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(723, 454);
            this.Controls.Add(this.btnCampeonatos);
            this.Controls.Add(this.btnJogos3);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnMinimizar);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.Button btnJogos3;
        private System.Windows.Forms.Button btnCampeonatos;
    }
}

