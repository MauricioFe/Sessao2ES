namespace Sessao2.ModuloMarketing
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
            this.Dgvjogos = new System.Windows.Forms.DataGridView();
            this.Campeonato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codcamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEstadio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtTime1 = new System.Windows.Forms.RadioButton();
            this.rbtTime2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvjogos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnMinimizar.Image = global::Sessao2.ModuloMarketing.Properties.Resources._1;
            this.btnMinimizar.Location = new System.Drawing.Point(870, 86);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(39, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 36;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnFechar.Image = global::Sessao2.ModuloMarketing.Properties.Resources._2;
            this.btnFechar.Location = new System.Drawing.Point(835, 44);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(39, 25);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 37;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // Dgvjogos
            // 
            this.Dgvjogos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgvjogos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campeonato,
            this.Time1,
            this.Time2,
            this.Estadio,
            this.Resultado,
            this.Codcamp,
            this.codTime1,
            this.codTime2,
            this.codEstadio});
            this.Dgvjogos.Location = new System.Drawing.Point(281, 156);
            this.Dgvjogos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Dgvjogos.Name = "Dgvjogos";
            this.Dgvjogos.Size = new System.Drawing.Size(547, 203);
            this.Dgvjogos.TabIndex = 38;
            // 
            // Campeonato
            // 
            this.Campeonato.HeaderText = "Campeonato";
            this.Campeonato.Name = "Campeonato";
            this.Campeonato.ReadOnly = true;
            // 
            // Time1
            // 
            this.Time1.HeaderText = "Time1";
            this.Time1.Name = "Time1";
            this.Time1.ReadOnly = true;
            // 
            // Time2
            // 
            this.Time2.HeaderText = "Time2";
            this.Time2.Name = "Time2";
            this.Time2.ReadOnly = true;
            // 
            // Estadio
            // 
            this.Estadio.HeaderText = "Estadio";
            this.Estadio.Name = "Estadio";
            this.Estadio.ReadOnly = true;
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            // 
            // Codcamp
            // 
            this.Codcamp.HeaderText = "codCampo";
            this.Codcamp.Name = "Codcamp";
            this.Codcamp.ReadOnly = true;
            this.Codcamp.Visible = false;
            // 
            // codTime1
            // 
            this.codTime1.HeaderText = "codTime1";
            this.codTime1.Name = "codTime1";
            this.codTime1.ReadOnly = true;
            this.codTime1.Visible = false;
            // 
            // codTime2
            // 
            this.codTime2.HeaderText = "codTime2";
            this.codTime2.Name = "codTime2";
            this.codTime2.ReadOnly = true;
            this.codTime2.Visible = false;
            // 
            // codEstadio
            // 
            this.codEstadio.HeaderText = "codEstadio";
            this.codEstadio.Name = "codEstadio";
            this.codEstadio.ReadOnly = true;
            this.codEstadio.Visible = false;
            // 
            // rbtTime1
            // 
            this.rbtTime1.AutoSize = true;
            this.rbtTime1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.rbtTime1.Location = new System.Drawing.Point(390, 431);
            this.rbtTime1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbtTime1.Name = "rbtTime1";
            this.rbtTime1.Size = new System.Drawing.Size(74, 21);
            this.rbtTime1.TabIndex = 39;
            this.rbtTime1.TabStop = true;
            this.rbtTime1.Text = "Time 1";
            this.rbtTime1.UseVisualStyleBackColor = false;
            // 
            // rbtTime2
            // 
            this.rbtTime2.AutoSize = true;
            this.rbtTime2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.rbtTime2.Location = new System.Drawing.Point(648, 431);
            this.rbtTime2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbtTime2.Name = "rbtTime2";
            this.rbtTime2.Size = new System.Drawing.Size(74, 21);
            this.rbtTime2.TabIndex = 40;
            this.rbtTime2.TabStop = true;
            this.rbtTime2.Text = "Time 2";
            this.rbtTime2.UseVisualStyleBackColor = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sessao2.ModuloMarketing.Properties.Resources.modelo_formulario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1061, 623);
            this.Controls.Add(this.rbtTime2);
            this.Controls.Add(this.rbtTime1);
            this.Controls.Add(this.Dgvjogos);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnMinimizar);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgvjogos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.DataGridView Dgvjogos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campeonato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codcamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEstadio;
        private System.Windows.Forms.RadioButton rbtTime1;
        private System.Windows.Forms.RadioButton rbtTime2;
    }
}

