using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 
namespace minij.instructions.math
{
    class SWAP : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader){}
        public  override void  execute(Frame frame)
        {
            var val1 = frame.operandStack.pop();
            var val2 = frame.operandStack.pop();
            frame.operandStack.push(val2);
            frame.operandStack.push(val1);
        }

    }

}
