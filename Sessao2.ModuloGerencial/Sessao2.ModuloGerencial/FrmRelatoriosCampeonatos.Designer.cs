namespace Sessao2.ModuloGerencial
{
    partial class FrmRelatoriosCampeonatos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.cboTipoRelatorio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTabela = new System.Windows.Forms.DataGridView();
            this.dgvPares = new System.Windows.Forms.DataGridView();
            this.Campeonato1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Campeonato2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPares)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(882, 12);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(114, 25);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // cboTipoRelatorio
            // 
            this.cboTipoRelatorio.FormattingEnabled = true;
            this.cboTipoRelatorio.Items.AddRange(new object[] {
            "Listar para cada campeonato, a quantidade de vitórias, empates e derrotas de cada" +
                " time",
            "Listar aos pares, os campeonatos que estavam en andamento simultaneamente."});
            this.cboTipoRelatorio.Location = new System.Drawing.Point(203, 12);
            this.cboTipoRelatorio.Name = "cboTipoRelatorio";
            this.cboTipoRelatorio.Size = new System.Drawing.Size(673, 25);
            this.cboTipoRelatorio.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selecione um relatório";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgvPares);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.dgvTabela);
            this.panel1.Location = new System.Drawing.Point(24, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 595);
            this.panel1.TabIndex = 8;
            // 
            // chart1
            // 
            chartArea1.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Empates";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Vitorias";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Derrotas";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(966, 268);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // dgvTabela
            // 
            this.dgvTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTabela.Location = new System.Drawing.Point(3, 277);
            this.dgvTabela.Name = "dgvTabela";
            this.dgvTabela.Size = new System.Drawing.Size(966, 312);
            this.dgvTabela.TabIndex = 0;
            this.dgvTabela.Visible = false;
            // 
            // dgvPares
            // 
            this.dgvPares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPares.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campeonato1,
            this.Campeonato2});
            this.dgvPares.Location = new System.Drawing.Point(3, 3);
            this.dgvPares.Name = "dgvPares";
            this.dgvPares.Size = new System.Drawing.Size(767, 382);
            this.dgvPares.TabIndex = 2;
            this.dgvPares.Visible = false;
            // 
            // Campeonato1
            // 
            this.Campeonato1.HeaderText = "Campeonato1";
            this.Campeonato1.Name = "Campeonato1";
            this.Campeonato1.ReadOnly = true;
            // 
            // Campeonato2
            // 
            this.Campeonato2.HeaderText = "Campeonato2";
            this.Campeonato2.Name = "Campeonato2";
            this.Campeonato2.ReadOnly = true;
            // 
            // FrmRelatoriosCampeonatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1020, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.cboTipoRelatorio);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRelatoriosCampeonatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios Campeonatos";
            this.Load += new System.EventHandler(this.FrmRelatoriosCampeonatos_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPares)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ComboBox cboTipoRelatorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTabela;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dgvPares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campeonato1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campeonato2;
    }
}