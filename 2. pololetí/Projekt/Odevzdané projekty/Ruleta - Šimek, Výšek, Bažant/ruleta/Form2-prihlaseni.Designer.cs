namespace WindowsFormsApplication2
{
    partial class Prihlaseni
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonZapniRuletu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonZapniRuletu
            // 
            this.buttonZapniRuletu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZapniRuletu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonZapniRuletu.Location = new System.Drawing.Point(12, 36);
            this.buttonZapniRuletu.Name = "buttonZapniRuletu";
            this.buttonZapniRuletu.Size = new System.Drawing.Size(225, 29);
            this.buttonZapniRuletu.TabIndex = 9;
            this.buttonZapniRuletu.Text = "Jdeme hrát!";
            this.buttonZapniRuletu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonZapniRuletu.UseVisualStyleBackColor = true;
            this.buttonZapniRuletu.Click += new System.EventHandler(this.buttonZapniRuletu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Přihlašovací klíč:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 20);
            this.textBox1.TabIndex = 7;
            // 
            // Prihlaseni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 74);
            this.Controls.Add(this.buttonZapniRuletu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Prihlaseni";
            this.Text = "Form2_prihlaseni";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonZapniRuletu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}