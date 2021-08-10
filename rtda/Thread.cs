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
    public class Thread
    {
        private FrameStack frames;
        public int pc;



        public Thread() {
            frames = new FrameStack(1024);
        }


        public Frame newFrame(Method method)
        {
            Frame f = Frame.buildFrame(this, method);
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
