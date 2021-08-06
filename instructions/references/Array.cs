using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;
using minij.instructions;
using minij.rtda.heap;
using minij.rtda.heap.constantpool;

namespace minij.instructions.math
{

    //multianewarray
    class MULTIA_NEW_ARRAY : Instruction
    {
        public override void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
            this.index2 = reader.read();
        }
        public override void execute(Frame frame)
        {
            int[] len = new int[this.index2];
            for (int i = 0; i < len.Length; i++)
            {
                len[i] = frame.operandStack.popInt();

            }

            JObject obj = new JObject();
            ClassRef c = (ClassRef)frame.method.clazz.cpInfo[this.index];
            Class c2 = c.resloveClass();
            obj.clazz = c2;

            var type = c2.getArrayType();
            switch (type)
            {
                case "I": // int
                case "B": // byte
                case "Z": // boolean
                case "S": // short
                case "C": // char
                    obj.data = Array.CreateInstance(typeof(int), len);
                    break;
                case "L":
                    obj.data = Array.CreateInstance(typeof(long), len);
                    break;
                case "D":
                    obj.data = Array.CreateInstance(typeof(double), len);
                    break;
                case "F":
                    obj.data = Array.CreateInstance(typeof(float), len);
                    break;
                default: // object array
                    obj.data = Array.CreateInstance(typeof(JObject), len);
                    break;
            }

            frame.operandStack.pushRef(obj);
        }

    }



    class ANEW_ARRAY : Instruction
    {
        public override void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public override void execute(Frame frame)
        {

            var count = frame.operandStack.popInt();
            JObject obj = new JObject();
            obj.data = new JObject[count];

            ClassRef c = (ClassRef)frame.method.clazz.cpInfo[this.index];
            Class c2 = c.resloveClass();
            obj.clazz = c2.loader.load("[L" + c2.name);

            frame.operandStack.pushRef(obj);
        }

    }


    class NEW_ARRAY : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.read();
        }
        public  override void   execute(Frame frame)
        {

            var count = frame.operandStack.popInt();
            JObject obj = new JObject();

            switch (this.index)
            {
                case 10: // int
                case 8: // byte
                case 4: // boolean
                case 9: // short
                case 5: // char
                    obj.data = new int[count];
                    break;
                case 11:
                    obj.data = new long[count];
                    break;
                case 7:
                    obj.data = new double[count];
                    break;
                case 6:
                    obj.data = new float[count];
                    break;
            }

            frame.operandStack.pushRef(obj);
        }

    }


    class IASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader){}
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if(self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[]) self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }


    class SASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }

    class BASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;

            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }
    class CASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popInt();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }

    class LASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popLong();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (long[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }

    class FASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popFloat();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (float[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }

    class DASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popDouble();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (double[])self.data;

            if (index < 0 || index >= tmp.Length) {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }

    class AASTORE : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var val = frame.operandStack.popRef();
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (JObject[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            tmp[index] = val;
        }

    }

    class LALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (long[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushLong(tmp[index]);
        }

    }

    class FALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (float[])self.data;

            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }


            frame.operandStack.pushFloat(tmp[index]);
        }

    }

    class DALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (double[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushDouble(tmp[index]);
        }

    }

    class AALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (JObject[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushRef(tmp[index]);
        }

    }


    class BALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushInt(tmp[index]);
        }

    }


    class CALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushInt(tmp[index]);
        }

    }

    class SALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;


            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushInt(tmp[index]);
        }

    }

    class IALOAD : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var index = frame.operandStack.popInt();
            var self = frame.operandStack.popRef();

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }

            var tmp = (int[])self.data;



            if (index < 0 || index >= tmp.Length)
            {
                throw new Exception("IndexOutOfRangeException");
            }

            frame.operandStack.pushInt(tmp[index]);
        }

    }
}
