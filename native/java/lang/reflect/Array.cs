using minij.classfile;
using minij.instructions;
using minij.rtda;
using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minij.native.java.lang.reflect
{

    class Array_newArray : Instruction
    {
        public override void feachOperationCode(CodeReader reader) { }
        public override void execute(Frame frame)
        {
            var clzObj = frame.localVars.getRef(0);
            var len = frame.localVars.getInt(1);
            if(null == clzObj)
            {
                throw new Exception("执行异常");
            }
            var clz = (Class) clzObj.ext;
            var obj = clz.newObject();
            obj.data = clz.loader.load(clz.getArrayType()).newObject();
            
            frame.operandStack.pushRef(obj);


        }
    }
   
}
