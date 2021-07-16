using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    class JObject
    {
        public Class clazz;
        public object data;
        public object ext;


        public static JObject newJObject(Class clz) {
            string name = clz.name;

            JObject jobj = new JObject();
            jobj.clazz = clz;
            return jobj;

        }
    }
}
