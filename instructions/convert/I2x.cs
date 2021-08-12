using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;


// INT TO X
namespace minij.instructions.convert
{
    class I2B : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {}
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushInt((byte)val);
        }

    }

    class I2C : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushInt((char)val);
        }

    }

    class I2S : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushInt((UInt16)val);
        }

    }

    class I2L : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushLong((long)val);
        }

    }

    class I2F : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushFloat((float)val);
        }

    }

    class I2D : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.operandStack.pushDouble((double)val);
        }

    }

}
