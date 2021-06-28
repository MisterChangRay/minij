using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.math
{
    class ICONST_M1 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(-1);
        }

    }

    class ICONST_0 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(0);
        }

    }

    class ICONST_1 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {

        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(1);
        }

    }

    class ICONST_2 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {

        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(2);
        }

    }

    class ICONST_3 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {

        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(3);
        }

    }

    class ICONST_4 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {

        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(4);
        }

    }

    class ICONST_5 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {

        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushInt(5);
        }

    }





    class LCONST_0 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushLong(0);
        }

    }

    class LCONST_1 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushLong(1);
        }

    }

    



    class FCONST_0 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushFloat(0);
        }

    }

    class FCONST_1 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushFloat(1);
        }

    }

    class FCONST_2 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushFloat(2);
        }

    }



    class DCONST_0 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushDouble(0.0);
        }

    }
    class DCONST_1 : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushDouble(1.0);
        }

    }

 
    class ACONST_NULL : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            frame.operandStack.pushRef(null);
        }

    }
  
}
