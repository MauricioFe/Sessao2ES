namespace Sessao2.ModuloAdm
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
            this.btnJogos = new System.Windows.Forms.Button();
            this.btnJogadores = new System.Windows.Forms.Button();
            this.btnCampeonatos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnJogos
            // 
            this.btnJogos.FlatAppearance.BorderSize = 0;
            this.btnJogos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogos.Location = new System.Drawing.Point(378, 168);
            this.btnJogos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnJogos.Name = "btnJogos";
            this.btnJogos.Size = new System.Drawing.Size(233, 60);
            this.btnJogos.TabIndex = 0;
            this.btnJogos.Text = "Gerenciamento de jogos";
            this.btnJogos.UseVisualStyleBackColor = true;
            // 
            // btnJogadores
            // 
            this.btnJogadores.FlatAppearance.BorderSize = 0;
            this.btnJogadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogadores.Location = new System.Drawing.Point(378, 255);
            this.btnJogadores.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnJogadores.Name = "btnJogadores";
            this.btnJogadores.Size = new System.Drawing.Size(233, 60);
            this.btnJogadores.TabIndex = 1;
            this.btnJogadores.Text = "Gerenciamento de Jogadores";
            this.btnJogadores.UseVisualStyleBackColor = true;
            this.btnJogadores.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCampeonatos
            // 
            this.btnCampeonatos.FlatAppearance.BorderSize = 0;
            this.btnCampeonatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCampeonatos.Location = new System.Drawing.Point(378, 336);
            this.btnCampeonatos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCampeonatos.Name = "btnCampeonatos";
            this.btnCampeonatos.Size = new System.Drawing.Size(233, 60);
            this.btnCampeonatos.TabIndex = 2;
            this.btnCampeonatos.Text = "Gerenciamento de Campeonatos";
            this.btnCampeonatos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(361, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu WSTowers";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sessao2.ModuloAdm.Properties.Resources.modelo_formulario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 499);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCampeonatos);
            this.Controls.Add(this.btnJogadores);
            this.Controls.Add(this.btnJogos);
            this.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJogos;
        private System.Windows.Forms.Button btnJogadores;
        private System.Windows.Forms.Button btnCampeonatos;
        private System.Windows.Forms.Label label1;
    }
}

