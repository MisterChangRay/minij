using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.math
{
    class SIPUSH : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
            byte b1 = reader.read();
            byte b2 = reader.read();
            int c = ((int)b1) << 8 | (int)b2;

            this.index = c;
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(this.index);
        }

    }

}
