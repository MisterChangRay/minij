using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
LocalVariableTable_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 local_variable_table_length;
    {   u2 start_pc;
        u2 length;
        u2 name_index;
        u2 descriptor_index;
        u2 index;
    } local_variable_table[local_variable_table_length];
}

**/
namespace minij.classfile.attributes
{
    class AttrLocalVariableTable : Attribute
    {
     
        public UInt16 local_variable_table_length;
        public List<LocalVariableTableLength> reslocalVariabletablelength;
      
        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            
            this.local_variable_table_length = classReader.readUInt16();
            this.reslocalVariabletablelength = new List<LocalVariableTableLength>();

            for (int i = 0; i < this.attribute_length; i++)
            {
                LocalVariableTableLength l = new LocalVariableTableLength();
                l.start_pc = classReader.readUInt16();
                l.length = classReader.readUInt16();
                l.name_index = classReader.readUInt16();
                l.descriptor_index = classReader.readUInt16();
                l.index = classReader.readUInt16();
                this.reslocalVariabletablelength.Add(l);
            }

            return this;

        }
    }

    class LocalVariableTableLength {
        public UInt16 start_pc;
        public UInt16 length;
        public UInt16 name_index;
        public UInt16 descriptor_index;
        public UInt16 index;
    }
}
