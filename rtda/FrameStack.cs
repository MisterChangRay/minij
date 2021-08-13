using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.native.java.lang;
using minij.classfile.attributes;

namespace minij.rtda
{
    class FrameStack
    {
        private Frame[] stcks;
        private int index = 0;

        public FrameStack(int i) {
            stcks = new Frame[i];
        }

        public void  push(Frame f)
        {
            stcks[index] = f;
            index++;

        }


        public Frame next()
        {
            return stcks[index - 2];
        }

        public List<StackTraceElement> getStackTraceElement()
        {
            List<StackTraceElement> res = new List<StackTraceElement>();
            for (int i = index - 1; i  > -1; i--)
            {
                StackTraceElement s = new StackTraceElement();
                var frame = this.stcks[i];
                s.fileName = frame.method.clazz.getFileName();
                s.className = frame.method.clazz.javaName0();
                AttrCode c = (AttrCode)frame.method.getAttribute("Code");
                s.lineNumber = c.getLineNum(frame.nextPc);
                s.methodName = frame.method.name;
                res.Add(s);
            }
            return res;
        }

        public Frame pop()
        {
            index--;
            return stcks[index];
        }

        public Frame top()
        {
            return stcks[index - 1];
        }

        internal bool isEmpty()
        {
            return index == 0;
        }
    }
}
