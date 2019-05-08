namespace WinFormPouzitiKnihovny
{
    partial class Form1
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
            this.btnPozdrav = new System.Windows.Forms.Button();
            this.txtJazyk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPozdrav
            // 
            this.btnPozdrav.Location = new System.Drawing.Point(30, 66);
            this.btnPozdrav.Name = "btnPozdrav";
            this.btnPozdrav.Size = new System.Drawing.Size(140, 52);
            this.btnPozdrav.TabIndex = 0;
            this.btnPozdrav.Text = "Pozdrav!";
            this.btnPozdrav.UseVisualStyleBackColor = true;
            this.btnPozdrav.Click += new System.EventHandler(this.btnPozdrav_Click);
            // 
            // txtJazyk
            // 
            this.txtJazyk.Location = new System.Drawing.Point(70, 40);
            this.txtJazyk.Name = "txtJazyk";
            this.txtJazyk.Size = new System.Drawing.Size(100, 20);
            this.txtJazyk.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jazyk:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 153);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJazyk);
            this.Controls.Add(this.btnPozdrav);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPozdrav;
        private System.Windows.Forms.TextBox txtJazyk;
        private System.Windows.Forms.Label label1;
    }
}

