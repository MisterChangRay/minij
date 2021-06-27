using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_String_info {
    u1 tag;
    u2 string_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_String_info : Constant
    {
        public UInt16 string_index;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {

            this.string_index = classReader.readUInt16();
            return this;
        }
    }
}
