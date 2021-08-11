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

            var clz = loader.load("java/lang/String");
            JObject jo =  clz.newObject();

            // 加载字符串数组
            var strVal = loader.load("[C").newObject();
            strVal.data = Mutf8.encode(val);


            // 设置字符串数组到 String 类中
            jo.setFieldVal("value", "[C", strVal);

            cache[val] = jo;
            return jo;
        }


        public static string toJString(JObject tmp3)
        {
            var tmp4 = tmp3.clazz.getField("value", "[C");
            var res = (JObject)((object
                [])tmp3.data)[tmp4.slotId];
            var res5 = (byte[])res.data;

          
        
            return Mutf8.decode(res5);
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




     class Mutf8
    {
        public static String decode(byte[] s )
        {
            MemoryStream ms = new MemoryStream(s);
            char[] c = new char[s.Length];
            return decode(ms, c);

        }
        /**
         * Decodes bytes from {@code in} into {@code out} until a delimiter 0x00 is
         * encountered. Returns a new string containing the decoded characters.
         */
        public static String decode(MemoryStream ina, char[] outb)
        {
        int s = 0;
        while (true && ina.Position < ina.Capacity) {
            char a = (char)(ina.ReadByte() & 0xff);
            if (a == 0) {
                return new String(outb, 0, s);
            }
            outb[s] = a;
            if (a< '\u0080') {
                s++;
            } else if ((a & 0xe0) == 0xc0) {
                int b = ina.ReadByte() & 0xff;
                if ((b & 0xC0) != 0x80) {
                    throw new Exception("bad second byte");
                }
                outb[s++] = (char) (((a & 0x1F) << 6) | (b & 0x3F));
            } else if ((a & 0xf0) == 0xe0) {
                int b = ina.ReadByte() & 0xff;
                int c = ina.ReadByte() & 0xff;
                if (((b & 0xC0) != 0x80) || ((c & 0xC0) != 0x80)) {
                    throw new Exception("bad second or third byte");
                }
                outb[s++] = (char) (((a & 0x0F) << 12) | ((b & 0x3F) << 6) | (c & 0x3F));
            } else {
                throw new Exception("bad byte");
            }
        }
            return new String(outb);
    }
    /**
     * Returns the number of bytes the modified UTF8 representation of 's' would take.
     */
    private static long countBytes(String s, bool shortLength)
{
        long result = 0;
        int length = s.Length;
        for (int i = 0; i < length; ++i) {
        char ch = s[i];
        if (ch != 0 && ch <= 127)
        { // U+0000 uses two bytes.
            ++result;
        }
        else if (ch <= 2047)
        {
            result += 2;
        }
        else
        {
            result += 3;
        }
        if (shortLength && result > 65535)
        {
            throw new Exception("String more than 65535 UTF bytes long");
        }
    }
        return result;
}
/**
 * Encodes the modified UTF-8 bytes corresponding to {@code s} into  {@code
 * dst}, starting at {@code offset}.
 */
public static void encode(byte[] dst, int offset, String s)
{
            int length = s.Length;
    for (int i = 0; i < length; i++)
    {
        char ch = s[i];
        if (ch != 0 && ch <= 127)
        { // U+0000 uses two bytes.
            dst[offset++] = (byte)ch;
        }
        else if (ch <= 2047)
        {
            dst[offset++] = (byte)(0xc0 | (0x1f & (ch >> 6)));
            dst[offset++] = (byte)(0x80 | (0x3f & ch));
        }
        else
        {
            dst[offset++] = (byte)(0xe0 | (0x0f & (ch >> 12)));
            dst[offset++] = (byte)(0x80 | (0x3f & (ch >> 6)));
            dst[offset++] = (byte)(0x80 | (0x3f & ch));
        }
    }
        }



        /**
         * Returns an array containing the <i>modified UTF-8</i> form of {@code s}.
         */
        public static byte[] encode(String s) 
{
        int utfCount = (int) countBytes(s, true);
        byte[] result = new byte[utfCount];
        encode(result, 0, s);
        return result;
}
}

}
