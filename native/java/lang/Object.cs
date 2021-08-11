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


    class Object_getClass : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var jobj = frame.localVars.getRef(0);
            var clzObj = (JObject)jobj.clazz.clzObj;
            frame.operandStack.pushRef(clzObj);

        }
    }


    class Object_hashCode : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var jobj = frame.localVars.getRef(0);
            frame.operandStack.pushInt(jobj.GetHashCode());

        }
    }


    


}
