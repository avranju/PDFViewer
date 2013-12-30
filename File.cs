using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFViewer
{
    public class File
    {
        public string Name { get; set; }
        public Uri Uri { get; set; }
        public string LocalPath { get; set; }
        public DateTime LastModified { get; set; }
        public byte[] Hash { get; set; }
        public long Size { get; set; }
        public FileStatus Status { get; set; }
    }
}
