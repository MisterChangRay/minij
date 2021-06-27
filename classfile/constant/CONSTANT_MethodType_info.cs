using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_MethodType_info {
    u1 tag;
    u2 descriptor_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_MethodType_info : Constant
    {
        public UInt16 descriptor_index;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
           
            this.descriptor_index = classReader.readUInt16();

            return this;
        }
    }
}
