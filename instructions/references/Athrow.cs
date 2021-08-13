using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;
using minij.instructions;
using minij.rtda.heap;
using minij.rtda.heap.constantpool;
using minij.native.java.lang;

namespace minij.instructions.references
{
    class ATHROW : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var ex = frame.operandStack.popRef();
            if(ex == null)
            {
                throw new Exception("NullPointerException");
            }

            var handle = frame.method.findCatchHandler(ex.clazz, frame.nextPc);
            if (handle == null)
            {
                frame.thread.cleanFrameStack();
                printException(ex);
                return;
            }

            frame.newBranch(handle.handler_pc);

        }

        private void printException(JObject ex)
        {

        //jMsg:= ex.GetRefVar("detailMessage", "Ljava/lang/String;")
        //goMsg:= heap.GoString(jMsg)
        //println(ex.Class().JavaName() + ": " + goMsg)

            List<StackTraceElement> res = (List<StackTraceElement>)ex.ext;
            var f = ex.clazz.getField("detailMessage", "Ljava/lang/String;");
            var fv = (JObject) ((object[])ex.data)[f.slotId];
            string msg = StringPool.toJString(fv);

            Console.WriteLine(ex.clazz.javaName0() + ": " + msg);
            res.ForEach(item => {
                Console.WriteLine("\tat {0}.{1}({2}:{3})", item.className, item.methodName, item.fileName, item.lineNumber);
            });
        }
    }


}
