using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;
using minij.rtda.heap.constantpool;

namespace minij.instructions.math
{
    class LDC : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public override void  execute(Frame frame)
        {
            var cp = frame.method.clazz.cpInfo[this.index];
            if (cp is Integer)
            {
                var cp2 = (Integer)cp;
                frame.operandStack.pushInt(cp2.val);
            }
            else if (cp is Float)
            {
                var cp2 = (Float)cp;
                frame.operandStack.pushFloat(cp2.val);
            }
            else {
                Console.WriteLine("錯誤的指令");
            }
            
        }

    }


    class LDC_W : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public override void  execute(Frame frame)
        {
            LDC l = new LDC();
            l.index = this.index;
            l.execute(frame);
        }

    }

    class LDC2_W : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public override void  execute(Frame frame)
        {
            var cp = frame.method.clazz.cpInfo[this.index];
            if (cp is Long)
            {
                var cp2 = (Long)cp;
                frame.operandStack.pushLong(cp2.val);
            }
            else if (cp is rtda.heap.constantpool.Double)
            {
                var cp2 = (rtda.heap.constantpool.Double)cp;
                frame.operandStack.pushDouble(cp2.val);
            }
            else
            {
                Console.WriteLine("錯誤的指令");
            }
        }

    }
}
