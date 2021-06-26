using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classpath
{
    class ZipReader : Reader
    {
        public string jarPath;

        public byte[] read(string className)
        {
           ZipArchive archive =  ZipFile.OpenRead(this.jarPath);
            foreach (ZipArchiveEntry entry in archive.Entries) {
                if (entry.FullName == className) {
                    byte[] res = new byte[entry.Length];
                    entry.Open().Read(res, 0, res.Length);
                    return res;
                }
            }

            return null;
        }



        public static ZipReader build(string jarpath2)
        {
            ZipReader zip = new ZipReader();
            zip.jarPath = jarpath2;
            return zip;
        }
    }
}
