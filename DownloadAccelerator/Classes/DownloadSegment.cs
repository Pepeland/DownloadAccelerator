using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadAccelerator.Classes
{
    internal class DownloadSegment
    {
        public int SegmentNumber { get; set; }
        public long StartRange { get; set; }
        public long EndRange { get; set; }
        public byte[] Data { get; set; }
        public int percentageCompleted { get; set; }
    }
}
