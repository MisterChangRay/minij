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

    

    class Double_ToRawLongBits : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.localVars.getDouble(0);

            long re = unchecked((long)BitConverter.DoubleToInt64Bits(val));
            frame.operandStack.pushLong(re);

        }
    }

   
}
