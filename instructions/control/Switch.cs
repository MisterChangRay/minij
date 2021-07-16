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
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
          
        }

    }


    class LOOKUPSWITCH : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {

        }

    }
}
