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

    

    class Class_desiredAssertionStatus0 : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            frame.operandStack.pushInt(0);

        }
    }

    class Class_getName0 : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var self = frame.localVars.getRef(0);
            var clz = (Class)self.ext;
            frame.operandStack.pushRef( clz.javaName());
            
        }
    }

    class Class_getPrimitiveClass : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {

            var self = frame.localVars.getRef(0);
            var jstr = StringPool.toJString((JObject)self);
            var clz = frame.method.clazz.loader.load(jstr);
            frame.operandStack.pushRef(clz.clzObj);
        }
    }
}
