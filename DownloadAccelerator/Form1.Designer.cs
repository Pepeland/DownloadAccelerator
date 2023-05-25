namespace DownloadAccelerator
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericConnections = new System.Windows.Forms.NumericUpDown();
            this.btnDownloadFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenDownloadFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericConnections)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(66, 60);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(2);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(519, 20);
            this.txtUrl.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(200, 165);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 8);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 25);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(495, 8);
            this.progressBar2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Download URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Download Folder";
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(66, 114);
            this.txtDownloadFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(480, 20);
            this.txtDownloadFolder.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Connection number:";
            // 
            // numericConnections
            // 
            this.numericConnections.Location = new System.Drawing.Point(66, 167);
            this.numericConnections.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericConnections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericConnections.Name = "numericConnections";
            this.numericConnections.Size = new System.Drawing.Size(120, 20);
            this.numericConnections.TabIndex = 14;
            this.numericConnections.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericConnections.ValueChanged += new System.EventHandler(this.numericConnections_ValueChanged);
            // 
            // btnDownloadFolder
            // 
            this.btnDownloadFolder.Location = new System.Drawing.Point(551, 112);
            this.btnDownloadFolder.Name = "btnDownloadFolder";
            this.btnDownloadFolder.Size = new System.Drawing.Size(34, 23);
            this.btnDownloadFolder.TabIndex = 15;
            this.btnDownloadFolder.Text = "...";
            this.btnDownloadFolder.UseVisualStyleBackColor = true;
            this.btnDownloadFolder.Click += new System.EventHandler(this.btnDownloadFolder_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.progressBar2);
            this.panel1.Location = new System.Drawing.Point(67, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 143);
            this.panel1.TabIndex = 16;
            // 
            // btnOpenDownloadFolder
            // 
            this.btnOpenDownloadFolder.AutoSize = true;
            this.btnOpenDownloadFolder.Location = new System.Drawing.Point(279, 165);
            this.btnOpenDownloadFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenDownloadFolder.Name = "btnOpenDownloadFolder";
            this.btnOpenDownloadFolder.Size = new System.Drawing.Size(121, 23);
            this.btnOpenDownloadFolder.TabIndex = 17;
            this.btnOpenDownloadFolder.Text = "Open download folder";
            this.btnOpenDownloadFolder.UseVisualStyleBackColor = true;
            this.btnOpenDownloadFolder.Click += new System.EventHandler(this.btnOpenDownloadFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 400);
            this.Controls.Add(this.btnOpenDownloadFolder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDownloadFolder);
            this.Controls.Add(this.numericConnections);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDownloadFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Download Accelerator";
            ((System.ComponentModel.ISupportInitialize)(this.numericConnections)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericConnections;
        private System.Windows.Forms.Button btnDownloadFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenDownloadFolder;
    }
}

