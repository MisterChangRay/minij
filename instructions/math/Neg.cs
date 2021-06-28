using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.math
{
    class INEG : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val3 = 0 - val1;
            frame.operandStack.pushInt(val3);
        }

    }

    class LNEG : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popLong();
            var val3 = 0 - val1;
            frame.operandStack.pushLong(val3);
        }

    }

    class FNEG : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popFloat();
            var val3 = 0 - val1;
            frame.operandStack.pushFloat(val3);
        }

    }


    class DNEG : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popDouble();
            var val3 = 0 - val1;
            frame.operandStack.pushDouble(val3);
        }

    }

}
