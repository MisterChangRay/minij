using minij.classfile;
using minij.classfile.attributes;
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
    public class Frame
    {
        public int nextPc;
        public CodeReader reader;
        public OperandStack operandStack;


        public LocalVars localVars;
        public Thread thread;
        public Method method;


        public Frame() {


        }

        public void reversePC() {
            this.nextPc = this.thread.pc;
        }
        public void setNextPc(int nextPc)
        {
            this.nextPc = nextPc;
        }

        public void  newBranch(int index)
        {
            var i = this.thread.pc + index;
            this.setNextPc(i);

        }

        public void doInvoke(Method method)
        {

            Frame newFrame = buildFrame(this.thread, method);
            copyArgs(this, newFrame, method);
            this.thread.pushFrame(newFrame);
        }

        // 复制方法调用时的参数
        private void copyArgs(Frame frame, Frame newFrame, Method method)
        {

            for (int i = method.argsAndReturn.argCount - 1; i >=0; i--)
            {
                var obj = frame.operandStack.pop();
                newFrame.localVars.set(i, obj);

            }
            
        }

        public static Frame buildFrame(Thread thread, Method method)
        {
            AttrCode code = (AttrCode)method.getAttribute("Code");
            CodeReader codeReader = new CodeReader(code.code);
            Frame f = new Frame();
            f.method = method;
            f.reader = codeReader;

            f.operandStack = new OperandStack(code.max_stack);
            f.localVars = new LocalVars(code.max_locals);
            f.thread = thread;

            return f;
        }


    }
}
