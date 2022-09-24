namespace DataBase
{
    partial class LeavingWithoutShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeavingWithoutShop));
            this.butto1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butto1
            // 
            this.butto1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butto1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butto1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butto1.BackgroundImage")));
            this.butto1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butto1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butto1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butto1.Location = new System.Drawing.Point(364, 73);
            this.butto1.Name = "butto1";
            this.butto1.Size = new System.Drawing.Size(93, 80);
            this.butto1.TabIndex = 0;
            this.butto1.UseVisualStyleBackColor = true;
            this.butto1.Click += new System.EventHandler(this.butto1_Click);
            // 
            // LeavingWithoutShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(490, 224);
            this.Controls.Add(this.butto1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeavingWithoutShop";
            this.Text = "LeavingWithoutShop";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butto1;
    }
}