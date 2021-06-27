using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_NameAndType_info {
    u1 tag;
    u2 name_index;
    u2 descriptor_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_NameAndType_info : Constant
    {
        public UInt16 nameIndex;
        public UInt16 descriptorIndex;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            
            this.nameIndex = classReader.readUInt16();
            this.descriptorIndex = classReader.readUInt16();

            return this;
        }
    }
}
