using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    public class JObject
    {
        public Class clazz;
        public object data;
        public object ext;


        public static JObject newJObject(Class clz) {
            string name = clz.name;

            JObject jobj = new JObject();
            jobj.clazz = clz;
            jobj.data = new object[clz.maxInstanceSlotId];
            return jobj;

        }

        public void setFieldVal(string name, string descriptor, JObject val)
        {
            var f = this.clazz.getField(name, descriptor);
            var tmp = (object[])this.data;
            tmp[f.slotId] = val;
        }
    }
}
