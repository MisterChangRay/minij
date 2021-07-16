using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;


// double TO X
namespace minij.instructions.math
{
    class D2I : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {}
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.operandStack.pushInt((int)val);
        }

    }

    class D2L : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.operandStack.pushLong((long)val);
        }

    }

    class D2F : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.operandStack.pushFloat((float)val);
        }

    }

}
