using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 左位移
namespace minij.instructions.math
{
    class ISHL : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val2 = frame.operandStack.popInt();
            var val3 = val2 << val1;
            frame.operandStack.pushInt(val3);
        }

    }

    class LSHL : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val2 = frame.operandStack.popLong();
            var val3 = val2 << val1;
            frame.operandStack.pushLong(val3);
        }

    }
}
