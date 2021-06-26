using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classpath
{
    class CombineReader : Reader
    {
        private List<Reader> reader = new List<Reader>();
        public byte[] read(string classname)
        {
            foreach (var item in reader) {
                byte[] res = item.read(classname);
                if (res != null) {
                    return res;
                }
            }
            
            return null;
        }

        public static CombineReader build(string dirpath)
        {
            CombineReader com = new CombineReader();
            string[] paths = dirpath.Split(Path.PathSeparator);

            foreach (var tmp in paths) {

                if (tmp.EndsWith("*"))
                {
                    string path = tmp.Replace("*", "");
                    if (System.IO.Directory.Exists(path))
                    {

                        DirectoryInfo d = new DirectoryInfo(path);
                        FileInfo[] fs = d.GetFiles();
                        foreach (var f in fs)
                        {
                            if (f.FullName.EndsWith(".jar") || f.FullName.EndsWith(".JAR"))
                            {
                                com.reader.Add(ZipReader.build(f.FullName));
                            }
                        }
                    }
                }
                else {
                    string path = tmp.Replace("*", "");
                    com.reader.Add(DirReader.build(path));
                }
            }

            return com;
        }
    }
}
