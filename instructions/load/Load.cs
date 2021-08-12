using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.load
{
    class ILOAD : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getInt(index);
            frame.operandStack.pushInt(val);
        }

    }

    class ILOAD_0 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getInt(0);
            frame.operandStack.pushInt(val);
        }

    }

    class ILOAD_1 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {

        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getInt(1);
            frame.operandStack.pushInt(val);
        }

    }

    class ILOAD_2 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {

        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getInt(2);
            frame.operandStack.pushInt(val);
        }

    }

    class ILOAD_3 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {

        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getInt(3);
            frame.operandStack.pushInt(val);
        }

    }

    class LLOAD : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getLong(index);
            frame.operandStack.pushLong(val);
        }

    }

    class LLOAD_0 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getLong(0);
            frame.operandStack.pushLong(val);
        }

    }

    class LLOAD_1 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getLong(1);
            frame.operandStack.pushLong(val);
        }

    }

    class LLOAD_2 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getLong(2);
            frame.operandStack.pushLong(val);
        }

    }

    class LLOAD_3 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getLong(3);
            frame.operandStack.pushLong(val);
        }

    }


    class FLOAD : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getFloat(index);
            frame.operandStack.pushFloat(val);
        }

    }

    class FLOAD_0 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getFloat(0);
            frame.operandStack.pushFloat(val);
        }

    }

    class FLOAD_1 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getFloat(1);
            frame.operandStack.pushFloat(val);
        }

    }

    class FLOAD_2 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getFloat(2);
            frame.operandStack.pushFloat(val);
        }

    }

    class FLOAD_3 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getFloat(3);
            frame.operandStack.pushFloat(val);
        }

    }

    class DLOAD : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getDouble(index);
            frame.operandStack.pushDouble(val);
        }

    }


    class DLOAD_0 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getDouble(0);
            frame.operandStack.pushDouble(val);
        }

    }
    class DLOAD_1 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getDouble(1);
            frame.operandStack.pushDouble(val);
        }

    }
    class DLOAD_2 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getDouble(2);
            frame.operandStack.pushDouble(val);
        }

    }
    class DLOAD_3 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getDouble(3);
            frame.operandStack.pushDouble(val);
        }

    }



    class ALOAD : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getRef(index);
            frame.operandStack.pushRef(val);
        }

    }


    class ALOAD_0 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getRef(0);
            frame.operandStack.pushRef(val);
        }

    }
    class ALOAD_1 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getRef(1);
            frame.operandStack.pushRef(val);
        }

    }
    class ALOAD_2 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getRef(2);
            frame.operandStack.pushRef(val);
        }

    }
    class ALOAD_3 : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.localVars.getRef(3);
            frame.operandStack.pushRef(val);
        }

    }
}
