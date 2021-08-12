using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.consts
{
    class SIPUSH : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public override void  execute(Frame frame)
        {
            frame.operandStack.pushInt(this.index);
        }

    }

}
