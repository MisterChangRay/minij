using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.rtda.heap;

namespace minij.rtda
{
    class Thread
    {
        private FrameStack frames;



        public Thread() {
            frames = new FrameStack(1024);
        }

        public Frame newFrame() {
            Frame f = new Frame();
            return f;
        }

        internal Frame newFrame(Method method)
        {
            throw new NotImplementedException();
        }


        public void pushFrame(Frame f)
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
