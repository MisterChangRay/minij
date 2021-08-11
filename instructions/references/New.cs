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

namespace minij.instructions.math
{
    class NEW : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var c = (ClassRef)frame.method.clazz.cpInfo[this.index];
            Class c2 = c.resloveClass();

            if (!c2.inited)
            {
                frame.reversePC();
                c2.doInit(frame);
                return;
            }

            JObject jo = c2.newObject();
            frame.operandStack.pushRef(jo);
            
        }

    }


}
