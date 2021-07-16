using minij.classfile;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
运行时栈帧

参考文档:
    https://docs.oracle.com/javase/specs/jvms/se7/html/jvms-2.html#jvms-2.6



**/
namespace minij.rtda
{
    class Frame
    {
        public int nextPc;
        public CodeReader reader;
        public OperandStack operandStack;
        public LocalVars localVars;
        public Thread thread;
        public Method method;


        public Frame() {


        }

        public void  newBranch(int index)
        {
            this.nextPc = this.nextPc + index;
        }
    }
}
