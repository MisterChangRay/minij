using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_Class_info {
    u1 tag;
    u2 name_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_Class : Constant
    {
        public UInt16 nameIndex;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.nameIndex = classReader.readUInt16();
            return this;
        }

       
    }
}
