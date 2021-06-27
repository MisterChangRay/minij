using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_InterfaceMethodref_info {
    u1 tag;
    u2 class_index;
    u2 name_and_type_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_InterfaceMethodref_info : Constant
    {
        public UInt16 classIndex;
        public UInt16 name_and_type_index;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {

            this.classIndex = classReader.readUInt16();
            this.name_and_type_index = classReader.readUInt16();
            return this;
        }
    }
}
