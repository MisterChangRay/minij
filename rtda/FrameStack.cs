using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.rtda
{
    class FrameStack
    {
        private Frame[] stcks;
        private int index = 0;

        public FrameStack(int i) {
            stcks = new Frame[i];
        }

        public   void  push(Frame f)
        {
            stcks[index] = f;
            index++;

        }


        public Frame next()
        {
            return stcks[index - 2];
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
