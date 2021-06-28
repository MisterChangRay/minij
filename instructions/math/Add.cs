﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.math
{
    class IINC : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
            this.index2 = reader.read();
        }
        public void execute(Frame frame)
        {
            var val1 = frame.localVars.getInt(this.index);
            var val = val1 + this.index2;
            frame.localVars.setInt(this.index, val);
        }

    }

    class IADD : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popInt();
            var val2 = frame.operandStack.popInt();
            var val3 = val1 + val2;
            frame.operandStack.pushInt(val3);
        }

    }

    class LADD : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popLong();
            var val2 = frame.operandStack.popLong();
            var val3 = val1 + val2;
            frame.operandStack.pushLong(val3);
        }

    }

    class FADD : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popFloat();
            var val2 = frame.operandStack.popFloat();
            var val3 = val1 + val2;
            frame.operandStack.pushFloat(val3);
        }

    }


    class DADD : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
        }
        public void execute(Frame frame)
        {
            var val1 = frame.operandStack.popDouble();
            var val2 = frame.operandStack.popDouble();
            var val3 = val1 + val2;
            frame.operandStack.pushDouble(val3);
        }

    }

}
