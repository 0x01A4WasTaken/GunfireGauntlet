namespace GunfireGauntlet.Engine
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnLoadGame = new System.Windows.Forms.Button();
            this.btnControls = new System.Windows.Forms.Button();
            this.GameLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadGame
            // 
            this.btnLoadGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadGame.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadGame.FlatAppearance.BorderSize = 0;
            this.btnLoadGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadGame.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadGame.Image")));
            this.btnLoadGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadGame.Name = "btnLoadGame";
            this.btnLoadGame.Size = new System.Drawing.Size(800, 154);
            this.btnLoadGame.Location = new System.Drawing.Point(240, 600);
            this.btnLoadGame.TabIndex = 0;
            this.btnLoadGame.UseVisualStyleBackColor = false;
            this.btnLoadGame.Click += new System.EventHandler(this.btnLoadGame_Click);
            // 
            // btnControls
            // 
            this.btnControls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnControls.BackColor = System.Drawing.Color.Transparent;
            this.btnControls.FlatAppearance.BorderSize = 0;
            this.btnControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControls.Image = ((System.Drawing.Image)(resources.GetObject("btnControls.Image")));
            this.btnControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnControls.Name = "btnControls";
            this.btnControls.Size = new System.Drawing.Size(800, 154);
            this.btnControls.Location = new System.Drawing.Point(240, 800);
            this.btnControls.TabIndex = 1;
            this.btnControls.UseVisualStyleBackColor = false;
            this.btnControls.Click += new System.EventHandler(this.btnControls_Click);
            // 
            // GameLogo
            // 
            this.GameLogo.BackColor = System.Drawing.Color.Transparent;
            this.GameLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.GameLogo.Image = ((System.Drawing.Image)(resources.GetObject("GameLogo.Image")));
            this.GameLogo.InitialImage = null;
            this.GameLogo.Location = new System.Drawing.Point(680, 192);
            this.GameLogo.Margin = new System.Windows.Forms.Padding(0);
            this.GameLogo.Name = "GameLogo";
            this.GameLogo.Size = new System.Drawing.Size(1200, 288);
            this.GameLogo.TabIndex = 2;
            this.GameLogo.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(2528, 1310);
            this.Controls.Add(this.GameLogo);
            this.Controls.Add(this.btnControls);
            this.Controls.Add(this.btnLoadGame);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenu";
            this.Text = "GunfireGauntlet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.GameLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadGame;
        private System.Windows.Forms.Button btnControls;
        private System.Windows.Forms.PictureBox GameLogo;
    }
}