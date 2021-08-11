using System;
using System.Collections;
using System.Collections.Generic;
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

            var clz = loader.load("java/lang/String");
            JObject jo =  clz.newObject();

            // 加载字符串数组
            var strVal = loader.load("[C").newObject();
            strVal.data = Encoding.Unicode.GetBytes(val);


            // 设置字符串数组到 String 类中
            jo.setFieldVal("value", "[C", strVal);

            cache[val] = jo;
            return jo;
        }


        public static string toJString(JObject tmp3)
        {
            var tmp4 = tmp3.clazz.getField("value", "[C");
            var res = (JObject)((object[])tmp3.data)[tmp4.slotId];
            var res5 = (byte[])res.data;

            if(res5.Length % 2 != 0)
            {
                byte[] n = new byte[res5.Length + 1];
                Array.Copy(res5, 0, n, 0, res5.Length);
                res5 = n;
            }
        
            return UnicodeEncoding.Unicode.GetString(res5);
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
