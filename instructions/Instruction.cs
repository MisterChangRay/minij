using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.instructions
{
    public abstract class Instruction
    {
        public int index;
        public int index2;
        public int index3;


        public virtual  void  feachOperationCode(CodeReader reader) { }
        public virtual  void  execute(Frame frame) { }
    }
}
