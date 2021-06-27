using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_InvokeDynamic_info {
    u1 tag;
    u2 bootstrap_method_attr_index;
    u2 name_and_type_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_InvokeDynamic_info : Constant
    {
        public UInt16 bootstrap_method_attr_index;
        public UInt16 name_and_type_index;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {

            this.bootstrap_method_attr_index = classReader.readUInt16();
            this.name_and_type_index = classReader.readUInt16();
            return this;
        }
    }
}
