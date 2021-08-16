using minij.classfile;
using minij.instructions;
using minij.rtda;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.native.java.lang
{
    class System_registerNatives : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {

        }


    }

    class System_arraycopy : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            //heap.ArrayCopy(src, dest, srcPos, destPos, length)

            var src = frame.localVars.getRef(0);
            var srcPos = frame.localVars.getInt(1);

            var dest = frame.localVars.getRef(2);

            int destPos = frame.localVars.getInt(3);
            int len = frame.localVars.getInt(4);

            var type = ((JObject)src).clazz.getArrayType();
            switch (type)
            {
                case "C": // char
                    Array.Copy((char[])src.data, srcPos,(char[]) dest.data, destPos, len);
                    break;
                case "I": // int
                case "B": // byte
                case "Z": // boolean
                case "S": // short
                    Array.Copy((int[])src.data, srcPos, (int[])dest.data, destPos, len);
                    break;
                case "L":
                    Array.Copy((long[])src.data, srcPos, (long[])dest.data, destPos, len);
                    break;
                case "D":
                    Array.Copy((double[])src.data, srcPos, (double[])dest.data, destPos, len);
                    break;
                case "F":
                    Array.Copy((float[])src.data, srcPos, (float[])dest.data, destPos, len);
                    break;
                default: // object array
                    Array.Copy((JObject[])src.data, srcPos, (JObject[])dest.data, destPos, len);
                    break;
            }


        }
    }
}
