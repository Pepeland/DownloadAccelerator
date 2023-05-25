using DownloadAccelerator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace DownloadAccelerator
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private DownloadManager dm;
        private Dictionary<int, System.Windows.Forms.ProgressBar> progressBars = new Dictionary<int, System.Windows.Forms.ProgressBar>();

        public Form1()
        {
            InitializeComponent();

            MakeProgressBars((int)numericConnections.Value);

            // Set up the Timer
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
        }

        private void MakeProgressBars(int count)
        {
            progressBars.Clear();
            panel1.Controls.Clear();

            var y = 12;
            for (int i = 1; i < count + 1; i++)
            {
                var progressBar = new ProgressBar();
                progressBar.Location = new Point(12, y);
                progressBar.Margin = new System.Windows.Forms.Padding(6, 2, 6, 2);
                progressBar.Size = new System.Drawing.Size(487, 8);
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                panel1.Controls.Add(progressBar);
                progressBars.Add(i, progressBar);
                y += 13;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                dm = new DownloadManager(txtUrl.Text, (int)numericConnections.Value, txtDownloadFolder.Text);
                dm.DownloadFile();
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidateForm()
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
                throw new Exception("Enter download URL");
            if (!IsValidUrl(txtUrl.Text))
                throw new Exception("URL is not valid");
            if (string.IsNullOrEmpty(txtDownloadFolder.Text))
                throw new Exception("Select download folder");
        }

        private static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var finishedSegments = 0;
            foreach (var seg in dm.DownloadSegments)
            {
                if (seg.Progress == 100) finishedSegments++;

                var progressBar = progressBars[seg.SegmentNumber];
                progressBar.Value = seg.Progress;
            }
            if (finishedSegments == dm.SegmentCount)
            {
                this.timer.Stop();
                MessageBox.Show("Download completed");
                ClearProgressBars();
            }
        }

        private void ClearProgressBars()
        {
            foreach (var seg in dm.DownloadSegments)
            {
                var progressBar = progressBars[seg.SegmentNumber];
                progressBar.Value = 0;
            }
        }

        private void numericConnections_ValueChanged(object sender, EventArgs e)
        {
            MakeProgressBars((int)numericConnections.Value);
        }

        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    txtDownloadFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
