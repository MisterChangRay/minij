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
            var clz = loader.load("java/lang/String");
            JObject jo =  clz.newObject();

            // 加载字符串数组
            var strVal = loader.load("[C").newObject();
            strVal.data = Encoding.Unicode.GetBytes(val);


            // 设置字符串数组到 String 类中
            jo.setFieldVal("value", "[C", strVal);

            return jo;
        }


        public static string toJString(JObject tmp3)
        {
            var tmp4 = tmp3.clazz.getField("value", "[C");
            var res = (JObject)((object[])tmp3.data)[tmp4.slotId];
            var res5 = (byte[])res.data;
            return UnicodeEncoding.Unicode.GetString(res5);
        }

        public static JObject getString(string code, JObject obj) {
            string key = obj.ext.ToString();

            if (cache.ContainsKey(key)) {
                return (JObject) cache[key];
            }

            cache[key] = obj;
            return obj;
        }

    }
}
