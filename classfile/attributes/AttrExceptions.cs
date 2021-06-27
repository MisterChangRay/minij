using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
Exceptions_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 number_of_exceptions;
    u2 exception_index_table[number_of_exceptions];
}

**/
namespace minij.classfile.attributes
{
    class AttrExceptions : Attribute
    {
       
        public UInt16 number_of_exceptions;
        public UInt16[] exception_index_table;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
   
            this.number_of_exceptions = classReader.readUInt16();
            this.exception_index_table = classReader.readUInt16s(this.number_of_exceptions);
            return this;
        }
    }
}
