namespace Sessao2.ModuloMarketing
{
    partial class FrmArte
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCampeonato = new System.Windows.Forms.Label();
            this.lblTime1 = new System.Windows.Forms.Label();
            this.lblTime2 = new System.Windows.Forms.Label();
            this.lblSeuTime = new System.Windows.Forms.Label();
            this.lblSuplentes = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblEstadio = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sessao2.ModuloMarketing.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(96, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCampeonato
            // 
            this.lblCampeonato.AutoSize = true;
            this.lblCampeonato.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampeonato.Location = new System.Drawing.Point(79, 149);
            this.lblCampeonato.Name = "lblCampeonato";
            this.lblCampeonato.Size = new System.Drawing.Size(298, 32);
            this.lblCampeonato.TabIndex = 1;
            this.lblCampeonato.Text = "Campeonato <Nome>";
            this.lblCampeonato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime1
            // 
            this.lblTime1.AutoSize = true;
            this.lblTime1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime1.Location = new System.Drawing.Point(142, 199);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(69, 21);
            this.lblTime1.TabIndex = 2;
            this.lblTime1.Text = "Time1";
            // 
            // lblTime2
            // 
            this.lblTime2.AutoSize = true;
            this.lblTime2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime2.Location = new System.Drawing.Point(265, 199);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(64, 21);
            this.lblTime2.TabIndex = 3;
            this.lblTime2.Text = "Time2";
            // 
            // lblSeuTime
            // 
            this.lblSeuTime.AutoSize = true;
            this.lblSeuTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeuTime.Location = new System.Drawing.Point(143, 242);
            this.lblSeuTime.Name = "lblSeuTime";
            this.lblSeuTime.Size = new System.Drawing.Size(190, 21);
            this.lblSeuTime.TabIndex = 4;
            this.lblSeuTime.Text = "Seu time em campo!";
            // 
            // lblSuplentes
            // 
            this.lblSuplentes.AutoSize = true;
            this.lblSuplentes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuplentes.Location = new System.Drawing.Point(351, 310);
            this.lblSuplentes.Name = "lblSuplentes";
            this.lblSuplentes.Size = new System.Drawing.Size(107, 21);
            this.lblSuplentes.TabIndex = 5;
            this.lblSuplentes.Text = "Suplentes";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(209, 616);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(53, 22);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data";
            this.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEstadio
            // 
            this.lblEstadio.AutoSize = true;
            this.lblEstadio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadio.Location = new System.Drawing.Point(157, 638);
            this.lblEstadio.Name = "lblEstadio";
            this.lblEstadio.Size = new System.Drawing.Size(163, 22);
            this.lblEstadio.TabIndex = 8;
            this.lblEstadio.Text = "Nome do estádio";
            this.lblEstadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmArte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(45)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(471, 687);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEstadio);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblSuplentes);
            this.Controls.Add(this.lblSeuTime);
            this.Controls.Add(this.lblTime2);
            this.Controls.Add(this.lblTime1);
            this.Controls.Add(this.lblCampeonato);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmArte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmArte";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCampeonato;
        private System.Windows.Forms.Label lblTime1;
        private System.Windows.Forms.Label lblTime2;
        private System.Windows.Forms.Label lblSeuTime;
        private System.Windows.Forms.Label lblSuplentes;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblEstadio;
        private System.Windows.Forms.Button button1;
    }
}