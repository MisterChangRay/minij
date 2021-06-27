using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
CONSTANT_MethodHandle_info {
    u1 tag;
    u1 reference_kind;
    u2 reference_index;
}
**/
namespace minij.classfile.constant
{
    class CONSTANT_MethodHandle_info : Constant
    {
        public byte reference_kind;
        public UInt16 reference_index;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            
            this.reference_kind = classReader.readUint8();
            this.reference_index = classReader.readUInt16();

            return this;
        }
    }
}
