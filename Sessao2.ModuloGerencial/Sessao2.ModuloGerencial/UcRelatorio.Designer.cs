namespace Sessao2.ModuloGerencial
{
    partial class UcRelatorio
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCampeonato = new System.Windows.Forms.Panel();
            this.pnlRelatório = new System.Windows.Forms.Panel();
            this.lblCampeonato = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime2 = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.pnlCampeonato.SuspendLayout();
            this.pnlRelatório.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampeonato
            // 
            this.pnlCampeonato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(107)))));
            this.pnlCampeonato.Controls.Add(this.lblCampeonato);
            this.pnlCampeonato.ForeColor = System.Drawing.Color.White;
            this.pnlCampeonato.Location = new System.Drawing.Point(0, 0);
            this.pnlCampeonato.Name = "pnlCampeonato";
            this.pnlCampeonato.Size = new System.Drawing.Size(765, 40);
            this.pnlCampeonato.TabIndex = 0;
            // 
            // pnlRelatório
            // 
            this.pnlRelatório.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.pnlRelatório.Controls.Add(this.panel1);
            this.pnlRelatório.Controls.Add(this.pnlCampeonato);
            this.pnlRelatório.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRelatório.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRelatório.ForeColor = System.Drawing.Color.White;
            this.pnlRelatório.Location = new System.Drawing.Point(0, 0);
            this.pnlRelatório.Name = "pnlRelatório";
            this.pnlRelatório.Size = new System.Drawing.Size(767, 89);
            this.pnlRelatório.TabIndex = 0;
            // 
            // lblCampeonato
            // 
            this.lblCampeonato.Location = new System.Drawing.Point(2, 8);
            this.lblCampeonato.Name = "lblCampeonato";
            this.lblCampeonato.Size = new System.Drawing.Size(763, 23);
            this.lblCampeonato.TabIndex = 0;
            this.lblCampeonato.Text = "Campeonato";
            this.lblCampeonato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblData);
            this.panel1.Controls.Add(this.lblResultado);
            this.panel1.Controls.Add(this.lblTime2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTime1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 47);
            this.panel1.TabIndex = 1;
            // 
            // lblTime1
            // 
            this.lblTime1.AutoSize = true;
            this.lblTime1.Location = new System.Drawing.Point(3, 13);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(56, 18);
            this.lblTime1.TabIndex = 0;
            this.lblTime1.Text = "Time1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "v";
            // 
            // lblTime2
            // 
            this.lblTime2.AutoSize = true;
            this.lblTime2.Location = new System.Drawing.Point(217, 13);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(56, 18);
            this.lblTime2.TabIndex = 2;
            this.lblTime2.Text = "Time2";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(435, 13);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(136, 18);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Vencedor: Casa";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(657, 13);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(96, 18);
            this.lblData.TabIndex = 4;
            this.lblData.Text = "13/03/2020";
            // 
            // UcRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRelatório);
            this.Name = "UcRelatorio";
            this.Size = new System.Drawing.Size(767, 89);
            this.pnlCampeonato.ResumeLayout(false);
            this.pnlRelatório.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCampeonato;
        private System.Windows.Forms.Label lblCampeonato;
        private System.Windows.Forms.Panel pnlRelatório;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblTime2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime1;
    }
}
