namespace GunfireGauntlet
{
    partial class GameWindow
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
            this.components = new System.ComponentModel.Container();
            this.tmrGameLoop = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCol = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrGameLoop
            // 
            this.tmrGameLoop.Enabled = true;
            this.tmrGameLoop.Interval = 1;
            this.tmrGameLoop.Tick += new System.EventHandler(this.GameLoop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            // 
            // lblCol
            // 
            this.lblCol.AutoSize = true;
            this.lblCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol.Location = new System.Drawing.Point(1438, 69);
            this.lblCol.Name = "lblCol";
            this.lblCol.Size = new System.Drawing.Size(169, 61);
            this.lblCol.TabIndex = 1;
            this.lblCol.Text = "label2";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(1364, 353);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(70, 25);
            this.lblMap.TabIndex = 2;
            this.lblMap.Text = "label2";
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1009);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.lblCol);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameWindow";
            this.Text = "GunfireGauntlet";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameLoop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCol;
        private System.Windows.Forms.Label lblMap;
    }
}

