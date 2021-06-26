using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classpath
{
    class DirReader : Reader
    {
        public string dirPath;

        public byte[] read(string className)
        {
            string path = Path.Combine(dirPath, className);
            if (System.IO.File.Exists(path)) {
                  return System.IO.File.ReadAllBytes(path); 

            };
            return null;
        }

        public static DirReader build(string dirpath)
        {
            dirpath = dirpath.Replace("*", "");
            DirReader zip = new DirReader();
            zip.dirPath = dirpath;
            return zip;
        }
    }
}
