using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 
namespace minij.instructions.stack
{
    class DUP : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader){}
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            frame.operandStack.push(val1);
            frame.operandStack.push(val1);
        }

    }



    class DUP_X1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader) { }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            var val2 = frame.operandStack.pop();

            frame.operandStack.push(val1);
            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
        }

    }


    class DUP_X2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader) { }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            var val2 = frame.operandStack.pop();
            var val3 = frame.operandStack.pop();

            frame.operandStack.push(val1);
            frame.operandStack.push(val3);
            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
        }

    }


    class DUP2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader) { }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            var val2 = frame.operandStack.pop();

            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
        }

    }


    class DUP2_X1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader) { }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            var val2 = frame.operandStack.pop();
            var val3 = frame.operandStack.pop();

            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
            frame.operandStack.push(val3);
            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
        }

    }

    class DUP2_X2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader) { }
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            var val2 = frame.operandStack.pop();
            var val3 = frame.operandStack.pop();
            var val4 = frame.operandStack.pop();

            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
            frame.operandStack.push(val4);
            frame.operandStack.push(val3);
            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
        }

    }
}
