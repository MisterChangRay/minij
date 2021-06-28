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
            var res = cache[name];
            if (res != null) {
                return res;
            }

            if (name.StartsWith("[")) {
                // 加载数组类
               return loadArrayClz(name);
            } else {
                // 加载非数组类
               return loadNoneArrayClz(name);
            }
        }

        private Class loadNoneArrayClz(string name)
        {
            // 非数组类需要判断是否为原生数据类型
            if (isPrimitive(name)) {
                return loadPrimitiveClz(name);
            }
            return loadObjectClz(name);
        }

        private Class loadObjectClz(string name)
        {
            throw new NotImplementedException();
        }

        private Class loadPrimitiveClz(string name)
        {
            throw new NotImplementedException();
        }

        private Class loadArrayClz(string name)
        {
            throw new NotImplementedException();
        }


        // 判断是否为原始类型
        public static bool isPrimitive(string name) {
            return primitive[name];
        }
    }
}
