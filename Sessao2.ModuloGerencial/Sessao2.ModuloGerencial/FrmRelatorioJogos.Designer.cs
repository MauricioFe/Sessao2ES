namespace Sessao2.ModuloGerencial
{
    partial class FrmRelatorioJogos
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnJogos3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione um relatório";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Jogos que fizeram uma equipe atuar em um intervalo menor que 3 dia",
            "Jogos em que a diferença salarial de um time para o outro seja menor que 50%",
            "jogos em que o time de menor folha salarial venceu"});
            this.comboBox1.Location = new System.Drawing.Point(191, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(636, 25);
            this.comboBox1.TabIndex = 1;
            // 
            // btnJogos3
            // 
            this.btnJogos3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnJogos3.FlatAppearance.BorderSize = 0;
            this.btnJogos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogos3.ForeColor = System.Drawing.Color.White;
            this.btnJogos3.Location = new System.Drawing.Point(833, 6);
            this.btnJogos3.Name = "btnJogos3";
            this.btnJogos3.Size = new System.Drawing.Size(107, 25);
            this.btnJogos3.TabIndex = 4;
            this.btnJogos3.Text = "Enviar";
            this.btnJogos3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 547);
            this.panel1.TabIndex = 5;
            // 
            // FrmRelatorioJogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(952, 596);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnJogos3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRelatorioJogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio Jogos";
            this.Load += new System.EventHandler(this.FrmRelatorioJogos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnJogos3;
        private System.Windows.Forms.Panel panel1;
    }
}