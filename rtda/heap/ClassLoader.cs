using minij.classfile;
using minij.classpath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    class ClassLoader
    {
        Classpath classpath = null;

        Dictionary<string, Class> cache = new Dictionary<string, Class>();
        static Dictionary<string, bool> primitive = new Dictionary<string, bool> {
            {"byte", true },
            {"boolean", true },
            {"char", true },
            {"short", true },
            {"int", true },
            {"long", true },
            {"float", true },
            {"double", true },
        };

        public ClassLoader(Classpath cp) {
            this.classpath = cp;
        }

        /**
            JAVA加载类时, 数组和原始类是内存封装的。
            其他类则到路径去加载
            **/
        public Class load(string name) {
            if (cache.Keys.Contains(name)) {
                var res = cache[name];
                if (res != null)
                {
                    return res;
                }
            }
            

            Class clz;
            if (name.StartsWith("[")) {
                // 加载数组类
                clz = loadArrayClz(name);
            } else {
                // 加载非数组类
                clz = loadNoneArrayClz(name);
            }

            cache[name] = clz;

            return clz;
        }

        private Class loadNoneArrayClz(string name)
        {
            // 非数组类需要判断是否为原生数据类型
            if (isPrimitive(name)) {
                return loadPrimitiveClz(name);
            }
            return loadObjectClz(name);
        }

        // 加载普通对象类型
        private Class loadObjectClz(string name)
        {
            var data = classpath.read(name);
            ClassFile clzFile = new ClassFile(data);
            clzFile.parse();

            Class clz = new Class();
            clz.loader = this;
            clz.init(clzFile);
            clz.initFieldsSolotId();
            clz.initFinalVars();
            return clz;

        }


        // 加载原始类型
        private Class loadPrimitiveClz(string name)
        {
            Class clz = new Class();
            clz.name = name;
            clz.accessFlags = new AccessFlags(0x0001);
            clz.loader = this;
            clz.superClazz = this.load("java.lang.Object");
            clz.clzObj =  clz.newObject();

            return clz; 
        }


        // 加载数组类型
        private Class loadArrayClz(string name)
        {
            Class clz = new Class();
            clz.name = name;
            clz.accessFlags = new AccessFlags(0x0001);
            clz.loader = this;
            clz.superClazz = this.load("java.lang.Object");
            clz.clzObj = clz.newObject();

            return clz;
        }


        // 判断是否为原始类型
        public static bool isPrimitive(string name) {
            return primitive.ContainsKey(name);
        }
    }
}
