using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;
using minij.rtda.heap.constantpool;

namespace minij.instructions.math
{
    class  Invokestatic : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader){
            this.index =  reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var mthodRefObj = frame.method.clazz.cpInfo[this.index];
            var methodRefo = (Methodref)mthodRefObj;
            var methodRef = methodRefo.resolveMethodref();

            var method = methodRef.clazz.getMethod(methodRef.nameAndType.name, methodRef.nameAndType.descriptor);
            if(!method.accessFlags.ACC_STATIC())
            {
                throw new ApplicationException("IncompatibleClassChangeError");
            }

            frame.doInvoke(method);
        }

    }

    class Invokevirtual : Instruction
    {
        public override void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public override void execute(Frame frame)
        {
            var mthodRefObj = frame.method.clazz.cpInfo[this.index];
            var methodRefo = (Methodref)mthodRefObj;
            var methodRef = methodRefo.resolveMethodref();
            if (methodRef.name == "println") {
                switch (methodRef.descriptor) {
                    case "(I)V":
                        var tmp = frame.operandStack.popInt();
                        Console.WriteLine(tmp);
                        break;
                    case "(J)V":
                        var tmp2 = frame.operandStack.popLong();
                        Console.WriteLine(tmp2);
                        break;
                }
                return;
            }

            var method = methodRef.clazz.getMethod(methodRef.nameAndType.name, methodRef.nameAndType.descriptor);

            frame.doInvoke(method);
        }

    }


    //invokespecial
    class InvokeSpecial : Instruction
    {
        public override void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public override void execute(Frame frame)
        {
            var mthodRefObj = frame.method.clazz.cpInfo[this.index];
            var methodRefo = (Methodref)mthodRefObj;
            var methodRef = methodRefo.resolveMethodref();
   
            var method = methodRef.clazz.getMethod(methodRef.nameAndType.name, methodRef.nameAndType.descriptor);
            if (method.accessFlags.ACC_STATIC())
            {
                throw new ApplicationException("IncompatibleClassChangeError");
            }

            frame.doInvoke(method);
        }

    }


}
