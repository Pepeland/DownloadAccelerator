using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadAccelerator.Classes
{
    public class DownloadManager
    {
        public ConcurrentDictionary<int, int> segmentProgress = new ConcurrentDictionary<int, int>();
        public int segmentCount;
        public string url;

        private long GetFileSize(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                long fileSize = response.ContentLength;
                return fileSize;
            }
        }

        public DownloadManager(string url, int segmentCount)
        {
            this.url = url;
            this.segmentCount = segmentCount;
            for (int i = 0; i < this.segmentCount; i++)
                segmentProgress.TryAdd(i+1, 0);
        }

        private List<DownloadSegment> DivideFileIntoSegments()
        {
            long fileSize = GetFileSize(url);

            long segmentSize = fileSize / segmentCount;

            List<DownloadSegment> segments = new List<DownloadSegment>();

            for (int i = 0; i < segmentCount; i++)
            {
                long startRange = i * segmentSize;
                long endRange = (i == segmentCount - 1) ? fileSize - 1 : startRange + segmentSize - 1;

                DownloadSegment segment = new DownloadSegment
                {
                    SegmentNumber = i + 1,
                    StartRange = startRange,
                    EndRange = endRange
                };

                segments.Add(segment);
            }

            return segments;
        }

        private async Task DownloadSegmentAsync(string url, DownloadSegment segment)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.AddRange(segment.StartRange, segment.EndRange);

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream responseStream = response.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                // to calculate progress percentage
                long totalBytesRead = 0;
                long totalBytesToRead = segment.EndRange - segment.StartRange + 1;

                while ((bytesRead = await responseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    memoryStream.Write(buffer, 0, bytesRead);

                    // to calculate progress percentage
                    totalBytesRead += bytesRead;
                    double percentage = (double)totalBytesRead / totalBytesToRead * 100;
                    segmentProgress[segment.SegmentNumber] = (int)percentage;
                }

                byte[] segmentData = memoryStream.ToArray();

                segment.Data = segmentData;
            }
        }

        private async Task DownloadSegmentsConcurrentlyAsync(List<DownloadSegment> segments, string url)
        {
            List<Task> downloadTasks = new List<Task>();

            foreach (DownloadSegment segment in segments)
            {
                downloadTasks.Add(DownloadSegmentAsync(url, segment));
            }

            await Task.WhenAll(downloadTasks);
        }

        private void CombineSegments(List<DownloadSegment> segments, string outputFilePath)
        {
            segments.Sort((a, b) => a.StartRange.CompareTo(b.StartRange));

            using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create))
            {
                foreach (DownloadSegment segment in segments)
                {
                    outputFileStream.Write(segment.Data, 0, segment.Data.Length);
                }
            }
        }

        public async void downloadFile()
        {
            var downloadSegments = this.DivideFileIntoSegments();
            await this.DownloadSegmentsConcurrentlyAsync(downloadSegments, url);
            var fileName = Path.GetFileName(url);
            this.CombineSegments(downloadSegments, fileName);
        }
    }
}
