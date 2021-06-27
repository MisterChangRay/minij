using System;
using System.Collections.Generic;

/**

方法和字段区  因为方法和字段都相同

field_info {
    u2             access_flags;
    u2             name_index;
    u2             descriptor_index;
    u2             attributes_count;
    attribute_info attributes[attributes_count];
}

**/
namespace minij.classfile
{
    class FieldAndMethodInfo : BaseInfo, Reader
    {
        public AccessFlags accessFlags;
        public UInt16 name_index;
        public UInt16 descriptor_index;
        public UInt16 attributes_count;
        public List<minij.classfile.attributes.Attribute> attrs;

        public Reader parse(ClassReader classReader, ClassFile cf)
        {

            UInt16 flags = classReader.readUInt16();
            accessFlags = new AccessFlags(flags);
            name_index = classReader.readUInt16();
            descriptor_index = classReader.readUInt16();
            attrs = cf.parseAttributes();
            this.attributes_count = Convert.ToUInt16( attrs.Count);
            return this;

        }
    }
}
