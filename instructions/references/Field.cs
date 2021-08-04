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
    class GET_FIELD : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {
            var self = (JObject)frame.operandStack.getThis();
            if (self == null)
            {
                throw new Exception("NullPointerException");
            }
            self = frame.operandStack.popRef();

            Fieldref fref = (Fieldref)frame.method.clazz.cpInfo[this.index];
            fref.resloveClass();
            var field = fref.resloveFieldref();

            switch (field.descriptor)
            {
                case "I": // int
                case "B": // byte
                case "Z": // boolean
                case "S": // short
                case "C": // char
                    frame.operandStack.pushInt((int) self.data[field.slotId]);
                    break;
                case "L":
                    frame.operandStack.pushLong((long)self.data[field.slotId]);
                    break;
                case "D":
                    frame.operandStack.pushDouble((double)self.data[field.slotId]);
                    break;
                case "F":
                    frame.operandStack.pushFloat((float)self.data[field.slotId]);
                    break;
                default: // object array
                    frame.operandStack.pushRef((JObject)self.data[field.slotId]);
                    break;
            }
        }

    }

    class PUT_FILED : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void  execute(Frame frame)
        {

            var self = (JObject) frame.operandStack.getThis();
            if (self == null) {
                throw new Exception("NullPointerException");
            }

            Fieldref fref =  (Fieldref)frame.method.clazz.cpInfo[this.index];
            fref.resloveClass();
            var field = fref.resloveFieldref();

            switch (field.descriptor) {
                case "I": // int
                case "B": // byte
                case "Z": // boolean
                case "S": // short
                case "C": // char
                    self.data[field.slotId] = frame.operandStack.popInt();
                    break;
                case "L":
                    self.data[field.slotId] = frame.operandStack.popLong();
                    break;
                case "D":
                    self.data[field.slotId] = frame.operandStack.popDouble();
                    break;
                case "F":
                    self.data[field.slotId] = frame.operandStack.popFloat();
                    break;
                default: // object array
                    self.data[field.slotId] = frame.operandStack.popRef();
                    break;
            }
        }
    }


    class GET_STATIC : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {

            var clz = frame.method.clazz;
            Fieldref r2 =  (Fieldref)clz.cpInfo[this.index];
            Field field = r2.resloveFieldref();

            if (!field.clazz.inited) {
                frame.reversePC();
                field.clazz.doInit(frame);
                return;
            }

            var tmp = field.clazz.staticVars[field.slotId];

            switch (field.descriptor)
            {
                case "Z":
                    // boolean
                    var boo = (int)tmp;
                    frame.operandStack.pushInt(boo);
                    break;
                case "B":
                    // byte
                    var b = (int) tmp;
                    frame.operandStack.pushInt(b);
                    break;
                case "C":
                    // char
                    var c = (int)tmp;
                    frame.operandStack.pushInt(c);
                    break;
                case "S":
                    // short
                    var s = (int)tmp;
                    frame.operandStack.pushInt(s);
                    break;
                case "I":
                    // int
                    var i = (int)tmp;
                    frame.operandStack.pushInt(i);
                    break;
                case "J":
                    // long
                    var l = (long)tmp;
                    frame.operandStack.pushLong(l);
                    break;
                case "F":
                    // float
                    var f = (float)tmp;
                    frame.operandStack.pushFloat(f);
                    break;
                case "D":
                    // double
                    var d = (double)tmp;
                    frame.operandStack.pushDouble(d);
                    break;

                default:
                    // obj
                    var obj = (JObject)tmp;
                    frame.operandStack.pushRef(obj);
                    break;
            }
        }

    }

    class PUT_STATIC : Instruction
    {
        public  override void   feachOperationCode(CodeReader reader)
        {
            this.index = reader.readUint16();
        }
        public  override void   execute(Frame frame)
        {

            var fieldRef = (Fieldref)frame.method.clazz.cpInfo[this.index];
            var field = fieldRef.resloveFieldref();
            if (!field.clazz.inited)
            {
                frame.reversePC();
                field.clazz.doInit(frame);
                return;
            }

            switch (field.descriptor) {
                case "Z":
                    // boolean
                    var boo = frame.operandStack.popInt();
                    field.clazz.staticVars[field.slotId] = boo;
                    break;
                case "B":
                    // byte
                    var b = frame.operandStack.popInt();
                    field.clazz.staticVars[field.slotId] = b;
                    break;
                case "C":
                    // char
                    var c = frame.operandStack.popInt();
                    field.clazz.staticVars[field.slotId] = c;
                    break;
                case "S":
                    // short
                    var s = frame.operandStack.popInt();
                    field.clazz.staticVars[field.slotId] = s;
                    break;
                case "I":
                    // int
                    var i = frame.operandStack.popInt();
                    field.clazz.staticVars[field.slotId] = i;
                    break;
                case "J":
                    // long
                    var l = frame.operandStack.popLong();
                    field.clazz.staticVars[field.slotId] = l;
                    break;
                case "F":
                    // float
                    var f = frame.operandStack.popFloat();
                    field.clazz.staticVars[field.slotId] = f;
                    break;
                case "D":
                    // double
                    var d = frame.operandStack.popDouble();
                    field.clazz.staticVars[field.slotId] = d;
                    break;
           
                default:
                    // obj
                    var obj = frame.operandStack.popRef();
                    field.clazz.staticVars[field.slotId] = obj;
                    break;
            }
        }

    }

}
