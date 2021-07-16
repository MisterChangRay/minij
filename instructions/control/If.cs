using minij.classfile;
using minij.rtda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ifeq, ifne, iflt, ifle, ifgt, ifge, ifnull, ifnonnull, if_icmpeq, if_icmpne, if_icmplt, if_icmple, if_icmpgt if_icmpge, if_acmpeq, if_acmpne.
namespace minij.instructions.control
{
    class IFEQ : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            if (0 == val) {
                frame.newBranch(this.index);
            }
        }

    }

    class IFNE : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            if (0 != val)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IFLT : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            if (0 > val)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IFLE : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            if (0 >= val)
            {
                frame.newBranch(this.index);
            }
        }

    }


    class IFGT : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            if (0 < val)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IFGE : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            if (0 <= val)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IFNULL : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            if (val == null)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IFNONNULL : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            if (val != null)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ICMPEQ : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popInt();
            var val1 = frame.operandStack.popInt();

            if (val1 == val2) {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ICMPNE : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popInt();
            var val1 = frame.operandStack.popInt();

            if (val1 != val2)
            {
                frame.newBranch(this.index);
            }
        }

    }


    class IF_ICMPLT : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popInt();
            var val1 = frame.operandStack.popInt();

            if (val1 < val2)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ICMPLE : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popInt();
            var val1 = frame.operandStack.popInt();

            if (val1 <= val2)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ICMPGT : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popInt();
            var val1 = frame.operandStack.popInt();

            if (val1 > val2)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ICMPGE : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popInt();
            var val1 = frame.operandStack.popInt();

            if (val1 >= val2)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ACMPEQ : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popRef();
            var val1 = frame.operandStack.popRef();

            if (val1 == val2)
            {
                frame.newBranch(this.index);
            }
        }

    }

    class IF_ACMPNEQ : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader) {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var val2 = frame.operandStack.popRef();
            var val1 = frame.operandStack.popRef();

            if (val1 != val2)
            {
                frame.newBranch(this.index);
            }
        }

    }
}
