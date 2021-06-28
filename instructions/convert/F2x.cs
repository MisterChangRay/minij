using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;


// FLOAT TO X
namespace minij.instructions.math
{
    class F2I : Instruction
    {
        public void feachOperationCode(CodeReader reader) {}
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.operandStack.pushInt((int)val);
        }

    }

    class F2L : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.operandStack.pushLong((long)val);
        }

    }

    class F2D : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.operandStack.pushDouble((double)val);
        }

    }



}
