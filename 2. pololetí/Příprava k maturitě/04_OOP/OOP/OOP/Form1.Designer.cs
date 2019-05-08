namespace OOP
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.barvyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.červenáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modráToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(395, 394);
            this.listBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(424, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 396);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barvyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // barvyToolStripMenuItem
            // 
            this.barvyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.červenáToolStripMenuItem,
            this.modráToolStripMenuItem});
            this.barvyToolStripMenuItem.Name = "barvyToolStripMenuItem";
            this.barvyToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.barvyToolStripMenuItem.Text = "Barvy";
            // 
            // červenáToolStripMenuItem
            // 
            this.červenáToolStripMenuItem.Name = "červenáToolStripMenuItem";
            this.červenáToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.červenáToolStripMenuItem.Text = "Červená";
            this.červenáToolStripMenuItem.Click += new System.EventHandler(this.ČervenáToolStripMenuItem_Click);
            // 
            // modráToolStripMenuItem
            // 
            this.modráToolStripMenuItem.Name = "modráToolStripMenuItem";
            this.modráToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modráToolStripMenuItem.Text = "Modrá";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem barvyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem červenáToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modráToolStripMenuItem;
    }
}

