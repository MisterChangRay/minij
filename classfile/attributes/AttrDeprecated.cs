using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
Deprecated_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
}
**/
namespace minij.classfile.attributes
{
    class AttrDeprecated : Attribute
    {
  
        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
           
            return this;
        }
    }
}
