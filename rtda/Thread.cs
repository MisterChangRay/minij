using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.rtda.heap;
using minij.classfile;
using minij.classfile.attributes;

namespace minij.rtda
{
    class Thread
    {
        private FrameStack frames;



        public Thread() {
            frames = new FrameStack(1024);
        }


        public Frame newFrame(Method method)
        {
            AttrCode code = (AttrCode) method.getAttribute("Code");
            CodeReader codeReader = new CodeReader(code.code);
            Frame f = new Frame();
            f.method = method;
            f.reader = codeReader;

            f.operandStack = new OperandStack(code.max_stack);
            f.localVars = new LocalVars(code.max_locals);
            f.thread = this;

            return f;
        }


        public   void  pushFrame(Frame f)
        {
            frames.push(f);
        }

        public Frame next()
        {
            return frames.next();
        }

        public Frame popFrame()
        {
            return frames.pop();
        }

        public Frame topFrame() {
            return frames.top();
        }

        public bool isEmpty()
        {
            return frames.isEmpty();
        }

        
    }
}
