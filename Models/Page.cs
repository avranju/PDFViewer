using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace PDFViewer.Models
{
    class Page
    {
        public ImageSource FullImage { get; set; }
        public ImageSource ThumbnailImage { get; set; }
        public int PageNumber { get; set; }
        public string Name { get; set; }
        public Uri Uri { get; set; }
    }
}
