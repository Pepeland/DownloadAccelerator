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

            progressBars.Add(1, progressBar1);
            progressBars.Add(2, progressBar2);
            progressBars.Add(3, progressBar3);
            progressBars.Add(4, progressBar4);
            progressBars.Add(5, progressBar5);
            progressBars.Add(6, progressBar6);

            // Set up the Timer
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            dm = new DownloadManager(txtUrl.Text, 6);
            dm.downloadFile();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var kvp in dm.segmentProgress)
            {
                int segmentId = kvp.Key;
                int progress = kvp.Value;

                System.Windows.Forms.ProgressBar progressBar = progressBars[segmentId];
                if (progressBar != null)
                {
                    progressBar.Value = progress;
                }
            }
        }
    }
}
