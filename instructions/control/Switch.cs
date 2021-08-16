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
            reader.pading();
            this.index = unchecked((int)reader.readUint32()); // default
            var len = unchecked((int)reader.readUint64()); // len
            this.index4 = reader.readInts(len);
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            int newPc = this.index;
            if (val >= 0 && val < this.index4.Length) {
                newPc = this.index4[val];
            }
            frame.setNextPc(frame.thread.pc + newPc);
        }

    }


    class LOOKUPSWITCH : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            reader.pading();
            this.index = unchecked( (int)reader.readUint32()); // default
            var len = unchecked((int)reader.readUint32()); // len
            this.index2 = len;
            len = len * 2;
            this.index4 = reader.readInts(len);
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            int newPc = this.index;

            for (int i = 0; i < this.index4.Length; i++)
            {
                if(newPc == this.index && this.index4[i] == val)
                {
                    newPc = this.index4[i + 1];
                    break;
                }
            }
            frame.setNextPc(frame.thread.pc + newPc);


        }

    }
}
