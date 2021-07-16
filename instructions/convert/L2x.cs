using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;


// LONG TO X
namespace minij.instructions.math
{
    class L2I : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {}
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.operandStack.pushInt((int)val);
        }

    }

    class L2F : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.operandStack.pushFloat((float)val);
        }

    }

    class L2D : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.operandStack.pushDouble((double)val);
        }

    }

}
