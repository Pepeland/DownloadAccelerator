using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DownloadAccelerator.Classes
{
    public class DownloadManager
    {
        public List<DownloadSegment> DownloadSegments = new List<DownloadSegment>();
        public int SegmentCount;
        public string Url;
        public string DownloadFolder;

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

        public DownloadManager(string url, int segmentCount, string downloadFolder)
        {
            this.Url = url;
            this.SegmentCount = segmentCount;
            this.DownloadFolder = downloadFolder;
        }

        private List<DownloadSegment> DivideFileIntoSegments()
        {
            long fileSize = GetFileSize(Url);

            long segmentSize = fileSize / SegmentCount;

            List<DownloadSegment> segments = new List<DownloadSegment>();

            for (int i = 0; i < SegmentCount; i++)
            {
                long startRange = i * segmentSize;
                long endRange = (i == SegmentCount - 1) ? fileSize - 1 : startRange + segmentSize - 1;

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
                    segment.Progress = (int)percentage;
                }

                byte[] segmentData = memoryStream.ToArray();

                segment.Data = segmentData;
            }
        }

        private async Task DownloadSegmentsConcurrentlyAsync(string url)
        {
            List<Task> downloadTasks = new List<Task>();

            foreach (DownloadSegment segment in this.DownloadSegments)
                downloadTasks.Add(DownloadSegmentAsync(url, segment));

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
                    segment.Data = null;
                }
            }
        }

        public async void DownloadFile()
        {
            ServicePointManager.DefaultConnectionLimit = SegmentCount;
            this.DownloadSegments = this.DivideFileIntoSegments();
            await this.DownloadSegmentsConcurrentlyAsync(Url);
            var filePath = DownloadFolder + "\\" + Path.GetFileName(Url);
            this.CombineSegments(DownloadSegments, filePath);
        }
    }
}
