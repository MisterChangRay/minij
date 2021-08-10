using minij.classfile;
using minij.native.java.lang;
using minij.rtda;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.instructions
{
    public  class NativeMethod
    {
        public static Hashtable cache = new Hashtable();

        public static void initNativeMethod()
        {
            register("registerNatives", "()V", new System_registerNatives());

            register("getPrimitiveClass", "(Ljava/lang/String;)Ljava/lang/Class;", new Class_getPrimitiveClass());

            register("getName0", "()Ljava/lang/String;", new Class_getName0());

            register("desiredAssertionStatus0", "(Ljava/lang/Class;)Z", new Class_desiredAssertionStatus0());

            register("getClass", "()Ljava/lang/Class;", new Object_getClass());


        }

        public static Instruction findMethod(string name, string desc) {
            string key = name + "_" + desc;
            if (!cache.ContainsKey(key)) return null;
            return (Instruction)cache[key];
        }


        public static void  register(string name, string desc, Instruction method) {
            string key = name + "_" + desc;
            if (cache.ContainsKey(key)) return;

            cache[key] = method;
        }
    }
}
