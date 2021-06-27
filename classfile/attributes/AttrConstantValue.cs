using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
ConstantValue_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 constantvalue_index;
}

**/
namespace minij.classfile.attributes
{
    class AttrConstantValue : Attribute
    {

        public UInt16 constantvalue_index;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
 
            this.constantvalue_index = classReader.readUInt16();
            return this;
        }
    }
}
