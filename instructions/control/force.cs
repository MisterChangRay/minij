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
        public void feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public void execute(Frame frame)
        {
            frame.newBranch(this.index);
        }

    }


    class GOTO_W : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint32();
        }
        public void execute(Frame frame)
        {
            frame.newBranch(this.index);
        }

    }
}
