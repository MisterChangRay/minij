using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;

namespace minij.instructions.store
{
    class ISTORE : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.localVars.setInt(index, val);
        }

    }

    class ISTORE_0 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.localVars.setInt(0, val);
        }

    }

    class ISTORE_1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {

        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.localVars.setInt(1, val);
        }

    }

    class ISTORE_2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {

        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.localVars.setInt(2, val);
        }

    }

    class ISTORE_3 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {

        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            frame.localVars.setInt(3, val);
        }

    }

    class LSTORE : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.localVars.setLong(index, val);
        }

    }

    class LSTORE_0 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.localVars.setLong(0, val);
        }

    }

    class LSTORE_1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.localVars.setLong(1, val);
        }

    }

    class LSTORE_2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.localVars.setLong(2, val);
        }

    }

    class LSTORE_3 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            frame.localVars.setLong(3, val);
        }

    }


    class FSTORE : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.localVars.setFloat(index, val);
        }

    }

    class FSTORE_0 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.localVars.setFloat(0, val);
        }

    }

    class FSTORE_1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.localVars.setFloat(1, val);
        }

    }

    class FSTORE_2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.localVars.setFloat(2, val);
        }

    }

    class FSTORE_3 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            frame.localVars.setFloat(3, val);
        }

    }

    class DSTORE : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.localVars.setDouble(index, val);
        }

    }


    class DSTORE_0 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.localVars.setDouble(0, val);
        }

    }
    class DSTORE_1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.localVars.setDouble(1, val);
        }

    }
    class DSTORE_2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.localVars.setDouble(2, val);
        }

    }
    class DSTORE_3 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            frame.localVars.setDouble(3, val);
        }

    }



    class ASTORE : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            frame.localVars.setRef(index, val);
        }

    }


    class ASTORE_0 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            frame.localVars.setRef(0, val);
        }

    }
    class ASTORE_1 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            frame.localVars.setRef(1, val);
        }

    }
    class ASTORE_2 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            frame.localVars.setRef(2, val);
        }

    }
    class ASTORE_3 : Instruction
    {
        public  override void  feachOperationCode(CodeReader reader)
        {
        }
        public  override void  execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            frame.localVars.setRef(3, val);
        }

    }
}
