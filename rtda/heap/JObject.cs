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

            initFieldVar(jobj, clz);
            return jobj;

        }


        // init instance field var
        private static void initFieldVar(JObject jobj, Class clz)
        {
            if(clz.fields == null)
            {
                return;
            }
            if (clz.superClazz != null) {
                initFieldVar(jobj, clz.superClazz);
            }

            object[] tmp = (object[])jobj.data;
            clz.fields.ForEach(f => {
                if (f.accessFlags.ACC_STATIC()) return;
                switch (f.descriptor) {
                    case "L":
                    case "[":
                        tmp[f.slotId] = null;
                        break;
                    default : 
                        tmp[f.slotId] = 0;
                        break;
                }
            });
           
        }

        public void setFieldVal(string name, string descriptor, JObject val)
        {
            var f = this.clazz.getField(name, descriptor);
            var tmp = (object[])this.data;
            tmp[f.slotId] = val;
        }
    }
}
