using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PDFViewer
{
    public class FilesCache
    {
        /// <summary>
        /// List of files managed by this object.
        /// </summary>
        private List<File> _files = new List<File>();

        public FilesCache(string filesDb)
        {
            LoadDatabase(filesDb);
        }

        async private void LoadDatabase(string filesDb)
        {
            // We wrap the "StreamReader" in a "StringReader" even
            // though a "StreamReader" can be directly passed to a
            // "JsonTextReader" because "JsonSerializer.Deserialize"
            // seems to be synhronous which means it'll read data from
            // the "StreamReader" synchronously causing the calling
            // thread to block on I/O; using an intermediate "StringReader"
            // allows us to call "ReadToEndAsync" to fetch the JSON in
            // one chunk asynchronously preventing blocking.
            var file = await StorageFile.GetFileFromPathAsync(filesDb);
            using(var stream = await file.OpenStreamForReadAsync())
            using(var streamReader = new StreamReader(stream))
            using(var stringReader = new StringReader(await streamReader.ReadToEndAsync()))
            using(var jsonReader = new JsonTextReader(stringReader))
            {
                var serializer = new JsonSerializer();
                var files = serializer.Deserialize<File[]>(jsonReader);
                _files.Clear();
                _files.AddRange(files);
            }
        }

        async private void SaveDatabase(string filesDb)
        {
            // since JSON.NET serialization is synchronous, we
            // first serialize to a memory stream synchronously
            // and then asynchronously copy the memory stream to file
            using(var memoryStream = new MemoryStream())
            using(var streamWriter = new StreamWriter(memoryStream))
            using(var jsonWriter = new JsonTextWriter(streamWriter))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, _files);

                // now copy memoryStream to file
                memoryStream.Position = 0;
                var file = await StorageFile.GetFileFromPathAsync(filesDb);
                using(var fileStream = await file.OpenStreamForWriteAsync())
                {
                    await memoryStream.CopyToAsync(fileStream);
                }
            }
        }
    }
}