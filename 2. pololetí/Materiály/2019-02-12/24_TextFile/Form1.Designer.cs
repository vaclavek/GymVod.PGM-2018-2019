﻿namespace Files
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
            this.btnUloz = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnNacti = new System.Windows.Forms.Button();
            this.txtVstup = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUloz
            // 
            this.btnUloz.Location = new System.Drawing.Point(11, 276);
            this.btnUloz.Name = "btnUloz";
            this.btnUloz.Size = new System.Drawing.Size(75, 23);
            this.btnUloz.TabIndex = 0;
            this.btnUloz.Text = "Ulož";
            this.btnUloz.UseVisualStyleBackColor = true;
            this.btnUloz.Click += new System.EventHandler(this.btnUloz_Click);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(12, 41);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(243, 229);
            this.txtText.TabIndex = 1;
            // 
            // btnNacti
            // 
            this.btnNacti.Location = new System.Drawing.Point(93, 277);
            this.btnNacti.Name = "btnNacti";
            this.btnNacti.Size = new System.Drawing.Size(75, 23);
            this.btnNacti.TabIndex = 2;
            this.btnNacti.Text = "Načti";
            this.btnNacti.UseVisualStyleBackColor = true;
            this.btnNacti.Click += new System.EventHandler(this.btnNacti_Click);
            // 
            // txtVstup
            // 
            this.txtVstup.Location = new System.Drawing.Point(13, 13);
            this.txtVstup.Name = "txtVstup";
            this.txtVstup.Size = new System.Drawing.Size(242, 20);
            this.txtVstup.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Načti obrázek";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(262, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(175, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Ulož SW";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 433);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtVstup);
            this.Controls.Add(this.btnNacti);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.btnUloz);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUloz;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnNacti;
        private System.Windows.Forms.TextBox txtVstup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
    }
}

