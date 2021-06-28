using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.math
{
    class BIPUSH : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(this.index);
        }

    }

}
