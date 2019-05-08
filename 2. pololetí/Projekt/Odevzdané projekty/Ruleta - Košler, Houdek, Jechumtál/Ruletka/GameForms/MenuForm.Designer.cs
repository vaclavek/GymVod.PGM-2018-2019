namespace Ruletka.GameForms
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonLoadGame = new System.Windows.Forms.Button();
            this.buttonCloseApp = new System.Windows.Forms.Button();
            this.buttonChangeLang = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNewGame
            // 
            resources.ApplyResources(this.buttonNewGame, "buttonNewGame");
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonLoadGame
            // 
            resources.ApplyResources(this.buttonLoadGame, "buttonLoadGame");
            this.buttonLoadGame.Name = "buttonLoadGame";
            this.buttonLoadGame.UseVisualStyleBackColor = true;
            this.buttonLoadGame.Click += new System.EventHandler(this.buttonLoadGame_Click);
            // 
            // buttonCloseApp
            // 
            resources.ApplyResources(this.buttonCloseApp, "buttonCloseApp");
            this.buttonCloseApp.Name = "buttonCloseApp";
            this.buttonCloseApp.UseVisualStyleBackColor = true;
            this.buttonCloseApp.Click += new System.EventHandler(this.buttonCloseApp_Click);
            // 
            // buttonChangeLang
            // 
            resources.ApplyResources(this.buttonChangeLang, "buttonChangeLang");
            this.buttonChangeLang.Name = "buttonChangeLang";
            this.buttonChangeLang.UseVisualStyleBackColor = true;
            this.buttonChangeLang.Click += new System.EventHandler(this.buttonChangeLang_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.FlatAppearance.BorderSize = 0;
            this.buttonHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.buttonHelp, "buttonHelp");
            this.buttonHelp.ForeColor = System.Drawing.Color.White;
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // MenuForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonChangeLang);
            this.Controls.Add(this.buttonCloseApp);
            this.Controls.Add(this.buttonLoadGame);
            this.Controls.Add(this.buttonNewGame);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonNewGame;
        public System.Windows.Forms.Button buttonLoadGame;
        public System.Windows.Forms.Button buttonCloseApp;
        private System.Windows.Forms.Button buttonChangeLang;
        private System.Windows.Forms.Button buttonHelp;
    }
}