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
            register("java/lang/System", "registerNatives", "()V", new System_registerNatives());
            register("java/lang/System", "arraycopy", "(Ljava/lang/Object;ILjava/lang/Object;II)V", new System_arraycopy());

            register("java/lang/Class", "getPrimitiveClass", "(Ljava/lang/String;)Ljava/lang/Class;", new Class_getPrimitiveClass());
            register("java/lang/Class", "getName0", "()Ljava/lang/String;", new Class_getName0());

            register("java/lang/Class", "desiredAssertionStatus0", "(Ljava/lang/Class;)Z", new Class_desiredAssertionStatus0());



            register("java/lang/Object", "getClass", "()Ljava/lang/Class;", new Object_getClass());

            register("java/lang/Float", "floatToRawIntBits", "(F)I", new Float_ToRawIntBits());
            register("java/lang/Double", "doubleToRawLongBits", "(D)L",new  Double_ToRawLongBits());

            register("java/lang/String", "intern", "()Ljava/lang/String;", new String_intern());


        }

        public static Instruction findMethod(string clzName, string methodName, string desc) {
            string key = clzName + "_" + methodName + "_" + desc;
            if (!cache.ContainsKey(key)) return null;
            return (Instruction)cache[key];
        }


        public static void  register(string clzName, string methodName, string desc, Instruction method) {
            string key = clzName + "_" + methodName + "_" + desc;
            if (cache.ContainsKey(key)) return;

            cache[key] = method;
        }
    }
}
