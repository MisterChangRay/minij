using minij.rtda.heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
异常表
     u2 exception_table_length;
    {   u2 start_pc;
        u2 end_pc;
        u2 handler_pc;
        u2 catch_type;
    } exception_table[exception_table_length];

**/
namespace minij.classfile
{
    public class ExceptionTable : Reader
    {
       public UInt16 start_pc;
       public UInt16 end_pc;
       public UInt16 handler_pc;
       public UInt16 catch_type;
       public ClassRef clzRef;

        public Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.start_pc = classReader.readUInt16();
            this.end_pc = classReader.readUInt16();
            this.handler_pc = classReader.readUInt16();
            this.catch_type = classReader.readUInt16();
            return this;
        }

   

    }
}
