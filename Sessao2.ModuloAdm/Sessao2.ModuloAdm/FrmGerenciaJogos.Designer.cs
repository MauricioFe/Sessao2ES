﻿namespace Sessao2.ModuloAdm
{
    partial class FrmGerenciaJogos
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
            this.dgvJogos = new System.Windows.Forms.DataGridView();
            this.Campeonato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEstadio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTime1 = new System.Windows.Forms.ComboBox();
            this.cboTime2 = new System.Windows.Forms.ComboBox();
            this.cboCampeonato = new System.Windows.Forms.ComboBox();
            this.cboEstadio = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.txtVencedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJogos
            // 
            this.dgvJogos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJogos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campeonato,
            this.Time1,
            this.Time2,
            this.Estadio,
            this.Data,
            this.Resultado,
            this.codCamp,
            this.codTime1,
            this.codTime2,
            this.codEstadio});
            this.dgvJogos.Location = new System.Drawing.Point(257, 265);
            this.dgvJogos.Name = "dgvJogos";
            this.dgvJogos.Size = new System.Drawing.Size(612, 235);
            this.dgvJogos.TabIndex = 0;
            this.dgvJogos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJogos_CellClick);
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
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.ReadOnly = true;
            // 
            // codCamp
            // 
            this.codCamp.HeaderText = "codCamp";
            this.codCamp.Name = "codCamp";
            this.codCamp.Visible = false;
            // 
            // codTime1
            // 
            this.codTime1.HeaderText = "codTime1";
            this.codTime1.Name = "codTime1";
            this.codTime1.Visible = false;
            // 
            // codTime2
            // 
            this.codTime2.HeaderText = "codTime2";
            this.codTime2.Name = "codTime2";
            this.codTime2.Visible = false;
            // 
            // codEstadio
            // 
            this.codEstadio.HeaderText = "codEstadio";
            this.codEstadio.Name = "codEstadio";
            this.codEstadio.Visible = false;
            // 
            // cboTime1
            // 
            this.cboTime1.FormattingEnabled = true;
            this.cboTime1.Location = new System.Drawing.Point(469, 126);
            this.cboTime1.Name = "cboTime1";
            this.cboTime1.Size = new System.Drawing.Size(121, 28);
            this.cboTime1.TabIndex = 1;
            // 
            // cboTime2
            // 
            this.cboTime2.FormattingEnabled = true;
            this.cboTime2.Location = new System.Drawing.Point(596, 126);
            this.cboTime2.Name = "cboTime2";
            this.cboTime2.Size = new System.Drawing.Size(121, 28);
            this.cboTime2.TabIndex = 2;
            // 
            // cboCampeonato
            // 
            this.cboCampeonato.FormattingEnabled = true;
            this.cboCampeonato.Location = new System.Drawing.Point(296, 126);
            this.cboCampeonato.Name = "cboCampeonato";
            this.cboCampeonato.Size = new System.Drawing.Size(167, 28);
            this.cboCampeonato.TabIndex = 3;
            // 
            // cboEstadio
            // 
            this.cboEstadio.FormattingEnabled = true;
            this.cboEstadio.Location = new System.Drawing.Point(723, 126);
            this.cboEstadio.Name = "cboEstadio";
            this.cboEstadio.Size = new System.Drawing.Size(121, 28);
            this.cboEstadio.TabIndex = 4;
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(311, 178);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(256, 25);
            this.dtpData.TabIndex = 5;
            // 
            // txtVencedor
            // 
            this.txtVencedor.Location = new System.Drawing.Point(573, 178);
            this.txtVencedor.Name = "txtVencedor";
            this.txtVencedor.Size = new System.Drawing.Size(240, 25);
            this.txtVencedor.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(300, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Campeonato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(466, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Time 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(720, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Estadio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(593, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(570, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Vencedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(53)))));
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(308, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Data";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(383, 530);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(97, 42);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(516, 530);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(97, 42);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(649, 530);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(97, 42);
            this.btnExcluir.TabIndex = 15;
            this.btnExcluir.Text = "Exluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sessao2.ModuloAdm.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnFechar.Image = global::Sessao2.ModuloAdm.Properties.Resources._2;
            this.btnFechar.Location = new System.Drawing.Point(849, 49);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 29);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 39;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(206)))), ((int)(((byte)(206)))));
            this.btnMinimizar.Image = global::Sessao2.ModuloAdm.Properties.Resources._1;
            this.btnMinimizar.Location = new System.Drawing.Point(886, 86);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 29);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 38;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // FrmGerenciaJogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sessao2.ModuloAdm.Properties.Resources.modelo_formulario;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1073, 650);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVencedor);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.cboEstadio);
            this.Controls.Add(this.cboCampeonato);
            this.Controls.Add(this.cboTime2);
            this.Controls.Add(this.cboTime1);
            this.Controls.Add(this.dgvJogos);
            this.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FrmGerenciaJogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGerenciaJogos";
            this.Load += new System.EventHandler(this.FrmGerenciaJogos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJogos;
        private System.Windows.Forms.ComboBox cboTime1;
        private System.Windows.Forms.ComboBox cboTime2;
        private System.Windows.Forms.ComboBox cboCampeonato;
        private System.Windows.Forms.ComboBox cboEstadio;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.TextBox txtVencedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campeonato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEstadio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnFechar;
        private System.Windows.Forms.PictureBox btnMinimizar;
    }
}