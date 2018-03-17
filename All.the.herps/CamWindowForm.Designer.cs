namespace All.the.herps
{
    partial class CamWindowForm
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
            this.btnGetCams = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetCams
            // 
            this.btnGetCams.Location = new System.Drawing.Point(12, 21);
            this.btnGetCams.Name = "btnGetCams";
            this.btnGetCams.Size = new System.Drawing.Size(116, 38);
            this.btnGetCams.TabIndex = 0;
            this.btnGetCams.Text = "available cams";
            this.btnGetCams.UseVisualStyleBackColor = true;
            this.btnGetCams.Click += new System.EventHandler(this.btnGetCams_Click);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenshot.Location = new System.Drawing.Point(1290, 21);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(115, 37);
            this.btnScreenshot.TabIndex = 1;
            this.btnScreenshot.Text = "Download screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Visible = false;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 589);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.btnGetCams);
            this.Name = "Form1";
            this.Text = "The herp derp camera thingie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetCams;
        private System.Windows.Forms.Button btnScreenshot;
    }
}

