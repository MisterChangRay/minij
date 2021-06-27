using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
    LocalVariableTypeTable_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 local_variable_type_table_length;
    {   u2 start_pc;
        u2 length;
        u2 name_index;
        u2 signature_index;
        u2 index;
    } local_variable_type_table[local_variable_type_table_length];
}
**/
namespace minij.classfile.attributes
{
    class AttrLocalVariableTypeTable : Attribute
    {
      
        public UInt16 local_variable_type_table_length;
        public List<LocalVariableTypeTable> localVariableTypeTable;

        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
        
            this.local_variable_type_table_length = classReader.readUInt16();
            this.localVariableTypeTable = new List<LocalVariableTypeTable>();

            for (int i = 0; i < this.local_variable_type_table_length; i++)
            {
                LocalVariableTypeTable l = new LocalVariableTypeTable();
                l.start_pc = classReader.readUInt16();
                l.length = classReader.readUInt16();
                l.name_index = classReader.readUInt16();
                l.signature_index = classReader.readUInt16();
                l.index = classReader.readUInt16();
                this.localVariableTypeTable.Add(l);
            }
            return this;
        }
    }

    class LocalVariableTypeTable
    {
        public UInt16 start_pc;
        public UInt16 length;
        public UInt16 name_index;
        public UInt16 signature_index;
        public UInt16 index;
    }
}
