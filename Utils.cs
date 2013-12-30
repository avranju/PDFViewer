using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace PDFViewer
{
    public static class Utils
    {
        public async static Task CopyStreamAsync(Stream istream, Stream ostream)
        {
            byte[] buffer = new byte[1024];
            int read = 0;
            while ((read = await istream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await ostream.WriteAsync(buffer, 0, read);
            }
        }
    }
}
