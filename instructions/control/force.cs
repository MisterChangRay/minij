using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Unconditional branch: goto, goto_w, jsr, jsr_w, ret.
namespace minij.instructions.control
{
    class GOTO : Instruction
    {
        public override void  feachOperationCode(CodeReader reader) {
            this.index = unchecked( (Int16)reader.readUint16()) ;
        }
        public override void  execute(Frame frame)
        {
            frame.newBranch(this.index);
        }

    }


    class GOTO_W : Instruction
    {
        public override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint32();
        }
        public override void  execute(Frame frame)
        {
            frame.newBranch(this.index);
        }

    }
}
