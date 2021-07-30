using System;
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
        public  override void   feachOperationCode(CodeReader reader){}
        public  override void   execute(Frame frame)
        {
            frame.thread.popFrame();
        }

    }


    class IRETURN : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader){}
        public  override void   execute(Frame frame)
        {
            var i = frame.operandStack.popInt();
            var preFrame = frame.thread.next();
            preFrame.operandStack.push(i);

            frame.thread.popFrame();
        }

    }


    class LRETURN : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var i = frame.operandStack.popLong();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushLong(i);

            frame.thread.popFrame();
        }

    }


    class FRETURN : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var i = frame.operandStack.popFloat();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushFloat(i);

            frame.thread.popFrame();
        }

    }


    class DRETURN : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var i = frame.operandStack.popDouble();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushDouble(i);

            frame.thread.popFrame();
        }

    }


    class ARETURN : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) { }
        public  override void   execute(Frame frame)
        {
            var i = frame.operandStack.popRef();
            var preFrame = frame.thread.next();
            preFrame.operandStack.pushRef(i);
            frame.thread.popFrame();
        }

    }

}
