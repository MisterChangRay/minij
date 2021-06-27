using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
LineNumberTable_attribute {
    u2 attribute_name_index;
    u4 attribute_length;
    u2 line_number_table_length;
    {   u2 start_pc;
        u2 line_number;	
    } line_number_table[line_number_table_length];
}

**/
namespace minij.classfile.attributes
{
    class AttrLineNumberTable : Attribute
    {

        public UInt16 line_number_table_length;
        public List<LineNumber> line_number_table;



        public override Reader parse(ClassReader classReader, ClassFile cf)
        {
            this.line_number_table_length = classReader.readUInt16();

            this.line_number_table = new List<LineNumber>();
            for (int i = 0; i < this.line_number_table_length; i++)
            {
                LineNumber l = new LineNumber();
                l.start_pc = classReader.readUInt16();
                l.line_number = classReader.readUInt16();
                this.line_number_table.Add(l);
            }

            return this;
        }
    }

    class LineNumber {
        public UInt16 start_pc;
        public UInt16 line_number;
     
    }
}
