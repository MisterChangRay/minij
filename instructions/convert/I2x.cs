using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;


// INT TO X
namespace minij.instructions.math
{
    class I2B : Instruction
    {
        public void feachOperationCode(CodeReader reader) {}
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushInt((byte)val);
        }

    }

    class I2C : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushInt((char)val);
        }

    }

    class I2S : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushInt((UInt16)val);
        }

    }

    class I2L : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushLong((long)val);
        }

    }

    class I2F : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushFloat((float)val);
        }

    }

    class I2D : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushDouble((double)val);
        }

    }

}
