namespace ProjetoAgenda
{
    partial class frmRelatorioDiario
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
            this.cb_dia = new System.Windows.Forms.ComboBox();
            this.gpBox = new System.Windows.Forms.GroupBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.gpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_dia
            // 
            this.cb_dia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dia.FormattingEnabled = true;
            this.cb_dia.Location = new System.Drawing.Point(59, 51);
            this.cb_dia.Name = "cb_dia";
            this.cb_dia.Size = new System.Drawing.Size(97, 28);
            this.cb_dia.TabIndex = 0;
            // 
            // gpBox
            // 
            this.gpBox.Controls.Add(this.btnGerar);
            this.gpBox.Controls.Add(this.cb_dia);
            this.gpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBox.Location = new System.Drawing.Point(34, 27);
            this.gpBox.Name = "gpBox";
            this.gpBox.Size = new System.Drawing.Size(266, 161);
            this.gpBox.TabIndex = 2;
            this.gpBox.TabStop = false;
            this.gpBox.Text = "Selecione o dia desejado";
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(90, 117);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(97, 38);
            this.btnGerar.TabIndex = 2;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            // 
            // frmRelatorioDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 218);
            this.Controls.Add(this.gpBox);
            this.Name = "frmRelatorioDiario";
            this.Text = "Relatório Diário";
            this.gpBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_dia;
        private System.Windows.Forms.GroupBox gpBox;
        private System.Windows.Forms.Button btnGerar;
    }
}