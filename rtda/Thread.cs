using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.rtda.heap;
using minij.classfile;
using minij.classfile.attributes;
using minij.native.java.lang;

namespace minij.rtda
{
    public class Thread
    {
        private FrameStack frames;
        public int pc;

        public List<StackTraceElement> getStackTraceElement()
        {
            return frames.getStackTraceElement();
        }


        public Thread() {
            frames = new FrameStack(1024);
        }


        public Frame newFrame(Method method)
        {
            Frame f = Frame.buildFrame(this, method);
            return f;
        }

        public ExceptionTable findCatchHandler(Class clazz)
        {
            ExceptionTable exet = null;

            while (!frames.isEmpty())
            {
                var method = frames.top().method;
                AttrCode code = (AttrCode)method.getAttribute("Code");
                if (null != code.exception_table)
                {
                    code.exception_table.ForEach(exl => {
                        ClassRef c = (ClassRef)method.clazz.cpInfo[exl.catch_type];
                        Class ex1 = c.resloveClass();
                        if (ex1 == clazz)
                        {
                            exet = exl;
                        }
                    });
                    if (null != exet)
                    {
                        break;
                    }
                }

                frames.pop();
            }
           
            return exet;
        }


    public   void  pushFrame(Frame f)
        {
            frames.push(f);
        }

        public void cleanFrameStack()
        {
            while(!frames.isEmpty())
            {
                this.frames.pop();
            }
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
