using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace cpShared.Helpers
{
    public class ZipHelper
    {
        public static void AddToZip(string filename, ZipArchive zip, MemoryStream msDocs)
        {
            ZipArchiveEntry zipItem = zip.CreateEntry(filename);
            using (Stream entryStream = zipItem.Open())
            {
                msDocs.Seek(0, SeekOrigin.Begin);
                msDocs.CopyTo(entryStream);
            }
        }

        public static void AddStreamToZip(string filename, ZipArchive zip, Stream stream)
        {
            ZipArchiveEntry zipItem = zip.CreateEntry(filename);
            using (Stream entryStream = zipItem.Open())
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(entryStream);
            }
        }
    }
}
