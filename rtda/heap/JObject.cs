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

        public JObject clone()
        {
            var o = this.clazz.newObject();
            if(this.clazz.isArray())
            {
                var type = this.clazz.getArrayType();
                switch (type)
                {
                    case "C": // char
                        byte[] src = ((byte[])this.data);
                        byte[] c = new byte[src.Length];
                        Array.Copy(src, 0, c, 0, src.Length);
                        o.data = c;
                        break;
                    case "I": // int
                    case "B": // byte
                    case "Z": // boolean
                    case "S": // short
                        int[] src1 = ((int[])this.data);
                        int[] c1 = new int[src1.Length];
                        Array.Copy(src1, 0, c1, 0, src1.Length);
                        o.data = c1;
                        break;
                    case "L":
                        long[] src2 = ((long[])this.data);
                        long[] c2 = new long[src2.Length];
                        Array.Copy(src2, 0, c2, 0, src2.Length);
                        o.data = c2;
                        break;
                    case "D":
                        double[] src3 = ((double[])this.data);
                        double[] c3 = new double[src3.Length];
                        Array.Copy(src3, 0, c3, 0, src3.Length);
                        o.data = c3;
                        break;
                    case "F":
                        float[] src4 = ((float[])this.data);
                        float[] c4 = new float[src4.Length];
                        Array.Copy(src4, 0, c4, 0, src4.Length);
                        o.data = c4;
                        break;
                    default: // object array
                        JObject[] src5 = ((JObject[])this.data);
                        JObject[] c5 = new JObject[src5.Length];
                        Array.Copy(src5, 0, c5, 0, src5.Length);
                        o.data = c5;
                        break;
                }
            } else if(this.clazz.isPrimitive())
            {
                o.data = this.data;
            } else
            {
                o.data = this.data;
            }

            return o;
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
                switch (f.descriptor[0]) {
                    case 'L':
                    case '[':
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
