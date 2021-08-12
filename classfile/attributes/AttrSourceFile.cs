using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
SourceFile_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 sourcefile_index;
}

**/
namespace minij.classfile.attributes
{
    class AttrSourceFile : Attribute
    {
     
        public UInt16 sourcefile_index;
        public string sourcefile;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
           
            this.sourcefile_index = classReader.readUInt16();
            this.sourcefile = cf.getString(this.sourcefile_index);
            return this;
        }
    }
}
