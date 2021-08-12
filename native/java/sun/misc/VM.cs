using minij.classfile;
using minij.instructions;
using minij.rtda;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.native.java.lang.sun.misc
{

    class VM_initialize : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var clz = frame.method.clazz;
            var field = clz.getField("savedProps", "Ljava/util/Properties;");

            var saveProps = (JObject)clz.staticVars[field.slotId];
            var key = StringPool.newString(clz.loader, "foo");
            var val = StringPool.newString(clz.loader, "bar");

            frame.operandStack.pushRef(saveProps);
            frame.operandStack.pushRef(key);
            frame.operandStack.pushRef(val);

            var pro = clz.loader.load("java/util/Properties");

            var method = pro.getMethod("setProperty", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/Object;");
            frame.doInvoke(method);
        }
    }

   
}
