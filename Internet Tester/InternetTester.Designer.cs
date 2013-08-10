namespace Internet_Tester
{
    partial class InternetTester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternetTester));
            this.lblStatus = new System.Windows.Forms.Label();
            this.InternetTestBW = new System.ComponentModel.BackgroundWorker();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.lblDeathCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatus.BackColor = System.Drawing.Color.Black;
            this.lblStatus.ForeColor = System.Drawing.Color.Yellow;
            this.lblStatus.Location = new System.Drawing.Point(43, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(203, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Checking internet connection...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // InternetTestBW
            // 
            this.InternetTestBW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InternetTestBW_DoWork);
            // 
            // pbStatus
            // 
            this.pbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbStatus.Image = global::Internet_Tester.Properties.Resources.suspicious;
            this.pbStatus.ImageLocation = "";
            this.pbStatus.Location = new System.Drawing.Point(0, 42);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(282, 213);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbStatus.TabIndex = 1;
            this.pbStatus.TabStop = false;
            // 
            // lblDeathCount
            // 
            this.lblDeathCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeathCount.BackColor = System.Drawing.Color.Black;
            this.lblDeathCount.ForeColor = System.Drawing.Color.Red;
            this.lblDeathCount.Location = new System.Drawing.Point(43, 26);
            this.lblDeathCount.Name = "lblDeathCount";
            this.lblDeathCount.Size = new System.Drawing.Size(203, 17);
            this.lblDeathCount.TabIndex = 2;
            this.lblDeathCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.lblDeathCount);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Internet Tester";
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker InternetTestBW;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Label lblDeathCount;
    }
}

