using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using minij.classfile;
using minij.rtda;
using minij.rtda.heap.constantpool;
using minij.rtda.heap;

namespace minij.instructions.math
{
    //invokeinterface
    class InvokeInterface : Instruction
    {
        public override void feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
            this.index2 = reader.read();
            this.index3 = reader.read();
        }
        public override void execute(Frame frame)
        {
            
            var mthodRefObj = frame.method.clazz.cpInfo[this.index];
            var methodRefo = (InterfaceMethodref)mthodRefObj;
            var methodRef = methodRefo.resolveMethodref();
            var method = methodRef.clazz.getMethod(methodRef.nameAndType.name, methodRef.nameAndType.descriptor);
            if (method.accessFlags.ACC_STATIC())
            {
                throw new ApplicationException("IncompatibleClassChangeError");
            }

            var self = (JObject)frame.operandStack.getThis(method.argsAndReturn.argCount - 1);

            if (self == null)
            {
                throw new Exception("NullPointerException");
            }
            method = self.clazz.getMethod(methodRef.nameAndType.name, methodRef.nameAndType.descriptor);

            frame.doInvoke(method);
        }

    }

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
            var methodRef2 = methodRef.clazz.getMethod(methodRef.nameAndType.name, methodRef.nameAndType.descriptor);

            var self = frame.operandStack.getThis(methodRef2.argsAndReturn.argCount - 1);
            if (self == null) {
                if (methodRef.name == "println")
                {
                    switch (methodRef.descriptor)
                    {
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

                throw new Exception("NullPointerException");
            }

            var method  = ((JObject)self).clazz.getMethod(methodRef.name, methodRef.descriptor);
            
         

            

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
