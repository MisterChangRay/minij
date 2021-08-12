using minij.classfile;
using minij.instructions;
using minij.rtda;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.native.java.lang
{

    class Throwable_fillInStackTrace : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var self = frame.localVars.getRef(0);
            frame.operandStack.pushRef(self);
            var ext = createStackTraceElements(self, frame.thread);
            self.ext = ext;
        }

        private List<StackTraceElement> createStackTraceElements(JObject self, Thread thread)
        {
            var skip = distanceToObject(self.clazz) + 2;
            List<StackTraceElement> res= thread.getStackTraceElement();
            return res.GetRange(skip, res.Count);
        }

        private int distanceToObject(Class clazz)
        {
            int i = 0;
            while(clazz.superClazz != null)
            {
                i++;
            }
            return i;
        }
    }


    public class StackTraceElement
    {
        public string fileName;
        public string className;
        public string methodName;
        public string lineNumber;
    }

}
