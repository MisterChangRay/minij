using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.classpath
{
    public class Classpath
    {
        Dictionary<string, byte[]> cache = new Dictionary<string, byte[]>();
        Reader bootClassPath = null;
        Reader extClassPath = null;
        Reader userClassPath = null;
        char sp = Path.DirectorySeparatorChar;

        public   void  init(JVMConfig config) {
            string jre = getJrePath();
            string jrelib = Path.Combine(jre, "lib", "*");
            this.bootClassPath = CombineReader.build(jrelib);
            string extlib = Path.Combine(jre, "lib", "ext", "*");
            this.extClassPath = CombineReader.build(extlib);
            this.userClassPath = CombineReader.build(getUserClassPath(config));

        }

        private string getUserClassPath(JVMConfig config)
        {
            if (config.cp != null) {
                return config.cp;
            }
            return "./";
        }

        public byte[] read(string filepath)
        {
            filepath = covertToPath(filepath);
            if (cache.ContainsKey(filepath))
            {
                return cache[filepath];
            }

            byte[] clz = bootClassPath.read(filepath);
            if (null != clz) {
                cache.Add(filepath, clz);
                return clz;
            }
            clz = extClassPath.read(filepath);
            if (null != clz)
            {
                cache.Add(filepath, clz);
                return clz;
            }
            clz = userClassPath.read(filepath);
            if (null != clz)
            {
                cache.Add(filepath, clz);
                return clz;
            }
            return null;

        }

        private string covertToPath(string filepath)
        {
            return filepath.Replace('.', '/') + ".class";
        }

        public static string getJrePath()
        {
            if (JVMConfig.config.Xjre != null) {
                return JVMConfig.config.Xjre;
            }

            if (System.IO.Directory.Exists("./jre")) {
                return "./jre";
            }

            string sPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            return sPath + "/jre";
        }
    }

 
    
}
