﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.math
{
    class  RETURN : Instruction
    {
        public void feachOperationCode(CodeReader reader){}
        public void execute(Frame frame)
        {
            frame.thread.popFrame();
        }

    }


    class IRETURN : Instruction
    {
        public void feachOperationCode(CodeReader reader){}
        public void execute(Frame frame)
        {
            var i = frame.operandStack.popInt();
            var preFrame = frame.thread.next();
            preFrame.operandStack.push(i);
        }

    }


    class LRETURN : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var i = frame.operandStack.popLong();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushLong(i);
        }

    }


    class FRETURN : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var i = frame.operandStack.popFloat();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushFloat(i);
        }

    }


    class DRETURN : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var i = frame.operandStack.popDouble();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushDouble(i);
        }

    }


    class ARETURN : Instruction
    {
        public void feachOperationCode(CodeReader reader) { }
        public void execute(Frame frame)
        {
            var i = frame.operandStack.popRef();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushRef(i);
        }

    }

}
