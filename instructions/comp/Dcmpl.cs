using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.comp
{
    class DCMPL : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
        }
        public override void  execute(Frame frame)
        {
            var v2 = frame.operandStack.popDouble();
            var v1 = frame.operandStack.popDouble();

            if (double.IsNaN(v1) || double.IsNaN(v2))
            {
                frame.operandStack.pushInt(-1);
            }
            else if (v1 > v2)
            {
                frame.operandStack.pushInt(1);
            }
            else if (v1 < v2)
            {
                frame.operandStack.pushInt(-1);
            }
            else
            {
                frame.operandStack.pushInt(0);
            }
        }

    }

}
