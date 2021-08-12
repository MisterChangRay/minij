using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.consts
{
    class BIPUSH : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public override void  execute(Frame frame)
        {
            frame.operandStack.pushInt(this.index);
        }

    }

}
