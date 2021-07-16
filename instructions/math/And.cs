using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// AND
namespace minij.instructions.math
{
    class IAND : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val2 = frame.operandStack.popInt();
            var val3 = val1 & val2;
            frame.operandStack.pushInt(val3);
        }

    }

    class LAND : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.popLong();
            var val2 = frame.operandStack.popLong();
            var val3 = val1 & val2;
            frame.operandStack.pushLong(val3);
        }

    }
}
