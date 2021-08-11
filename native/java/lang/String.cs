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
    class String_intern : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            //this := frame.LocalVars().GetThis()
            //interned:= heap.InternString(this)
            //frame.OperandStack().PushRef(interned)

            var self = frame.localVars.getRef(0);
            var newStr = StringPool.getString(self);
            frame.operandStack.pushRef(newStr);

        }


    }

    
}
