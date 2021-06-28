using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace minij.instructions.control
{
    class TABLESWITCH : Instruction
    {
        public void feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public void execute(Frame frame)
        {
          
        }

    }


    class LOOKUPSWITCH : Instruction
    {
        public void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public void execute(Frame frame)
        {

        }

    }
}
