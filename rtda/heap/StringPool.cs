using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda.heap
{
    class StringPool
    {

        public static Hashtable cache = new Hashtable();


        public static JObject newString(ClassLoader loader, string val) {
            if(cache.ContainsKey(val))
            {
                return (JObject)cache[val];
            }

            var clz = loader.load(StringPool.getStringDescriptor());
            JObject jo =  clz.newObject();

            // 加载字符串数组
            var strVal = loader.load("[C").newObject();
            strVal.data = val.ToCharArray();


            // 设置字符串数组到 String 类中
            jo.setFieldVal("value", "[C", strVal);

            cache[val] = jo;
            return jo;
        }


        public static string getStringDescriptor()
        {
            return "java/lang/String";
        }

        public static string getStringAsArrDescriptor()
        {
            return "[Ljava/lang/String;";
        }

        public static string toJString(JObject tmp3)
        {
            var tmp4 = tmp3.clazz.getField("value", "[C");
            var res = (JObject)((object
                [])tmp3.data)[tmp4.slotId];
            var res5 = (char[])res.data;



            return new String(res5);
        }

        

        public static JObject getString(JObject obj) {

            string key = toJString(obj);

            if (cache.ContainsKey(key)) {
                return (JObject) cache[key];
            }

            cache[key] = obj;
            return obj;
        }

    }




}
