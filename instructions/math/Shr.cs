using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 又位移
namespace minij.instructions.math
{

    class ISHR : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val2 = frame.operandStack.popLong();
            var val3 = val2 >> val1;
            frame.operandStack.pushLong(val3);
        }

    }


    class LSHR : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val2 = frame.operandStack.popLong();
            var val3 = val2 >> val1;
            frame.operandStack.pushLong(val3);
        }

    }
}
